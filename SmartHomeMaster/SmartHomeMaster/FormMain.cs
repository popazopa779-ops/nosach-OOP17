using System.Diagnostics;
using SmartHomeMaster.Data;
using SmartHomeMaster.Interfaces;
using SmartHomeMaster.Models;
using SmartHomeMaster.Services;

namespace SmartHomeMaster;

/// <summary>Модуль 5. Главное окно: TabControl с 4 вкладками.</summary>
public partial class FormMain : Form
{
    private readonly RoomRepository _roomRepo = new();
    private readonly DeviceRepository _deviceRepo = new();
    private readonly TelemetryRepository _telemetryRepo = new();
    private readonly SensorService _sensorService;

    private List<Room> _rooms = new();
    private List<Device> _devices = new();
    private List<TelemetryLog> _logs = new();
    private List<DeviceReportDto> _report = new();
    private List<DeviceReportDto> _sortedReport = new();
    private int _page = 1;

    public FormMain()
    {
        InitializeComponent();
        _sensorService = new SensorService(_telemetryRepo);
        Load += async (s, e) => await LoadDataAsync();
    }

    // ==================================================================
    // Обработчики интерфейса, подключаемые в FormMain.Designer.cs
    // ==================================================================
    private void OnClearLogClick(object? sender, EventArgs e) => _lstEvents.Items.Clear();

    private void OnPrevPageClick(object? sender, EventArgs e)
    {
        _page--;
        ShowPage();
    }

    private void OnNextPageClick(object? sender, EventArgs e)
    {
        _page++;
        ShowPage();
    }

    private void OnPageSizeChanged(object? sender, EventArgs e)
    {
        _page = 1;
        ShowPage();
    }

    // ==================================================================
    // Загрузка данных (асинхронно)
    // ==================================================================
    private async Task LoadDataAsync()
    {
        try
        {
            _rooms = await _roomRepo.GetAllAsync();
            _devices = await _deviceRepo.GetAllAsync();
            _logs = await _telemetryRepo.GetAllAsync();
            _report = LinqAnalytics.BuildReport(_rooms, _devices);
            BindAll();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BindAll()
    {
        _cmbRoom.DisplayMember = nameof(Room.Title);
        _cmbRoom.DataSource = _rooms.ToList();

        _cmbRoomA.DataSource = _rooms.Select(r => r.Title).ToList();
        _cmbRoomB.DataSource = _rooms.Select(r => r.Title).ToList();
        if (_cmbRoomB.Items.Count > 1) _cmbRoomB.SelectedIndex = 1;

        _cmbSensors.DisplayMember = nameof(Device.Model);
        _cmbSensors.DataSource = _devices.Where(d => d is SmartSensor).ToList();

        foreach (Device d in _devices)
        {
            d.StatusChanged -= OnDeviceStatusChanged;
            if (_chkSubscribe.Checked)
                d.StatusChanged += OnDeviceStatusChanged;
        }

        RefreshDevices();
        _sortedReport = LinqAnalytics.FilterSort(_report, 0);
        _page = 1;
        ShowPage();
        _gridReport.DataSource = _report.ToList();
    }

    private void RefreshDevices()
    {
        _gridDevices.DataSource = _devices.Select(d => new
        {
            d.Id,
            d.Model,
            Type = d.GetType().Name,
            d.Power,
            Consumption = Math.Round(d.CalculatePowerConsumption(), 2),
            Status = d.GetStatus(),
            d.RoomId,
            d.LastReading
        }).ToList();
    }

    private Device? GetSelectedDevice()
    {
        if (_gridDevices.CurrentRow is null) return null;
        int index = _gridDevices.CurrentRow.Index;
        return index >= 0 && index < _devices.Count ? _devices[index] : null;
    }

    private void Log1(string text) => _txtLog1.AppendText(text + Environment.NewLine);

    // ==================================================================
    // Вкладка 1: ООП, Generics, интерфейсы
    // ==================================================================
    private void OnSortClick(object? sender, EventArgs e)
    {
        _devices.Sort(); // использует IComparable<Device>.CompareTo (по Power)
        RefreshDevices();
        Log1("Список отсортирован по мощности (IComparable<Device>).");
    }

    private void OnDeepCopyClick(object? sender, EventArgs e)
    {
        Device? original = GetSelectedDevice();
        if (original is null)
        {
            MessageBox.Show("Выберите устройство в таблице.");
            return;
        }

        var copy = (Device)original.Clone();
        copy.Calibration.Offset = original.Calibration.Offset + 1.5; // меняем только копию

        Log1("--- Deep Copy (ICloneable) ---");
        Log1($"Оригинал: {original}");
        Log1($"Копия:    {copy}");
        Log1($"ReferenceEquals(original, copy) = {ReferenceEquals(original, copy)}");
        Log1($"ReferenceEquals(Calibration) = {ReferenceEquals(original.Calibration, copy.Calibration)} (при Deep Copy должно быть False)");
        Log1($"Сдвиг калибровки: оригинал {original.Calibration.Offset}, копия {copy.Calibration.Offset} (оригинал не изменился)");
        Log1($"original.Equals(copy) = {original.Equals(copy)} (сравнение по Id и Model)");
    }

    private void OnToggleClick(object? sender, EventArgs e)
    {
        Device? d = GetSelectedDevice();
        if (d is null) return;
        d.SetActive(!d.IsActive); // вызывает событие StatusChanged
        RefreshDevices();
    }

    private void OnOopDemoClick(object? sender, EventArgs e)
    {
        Device? d = GetSelectedDevice();
        if (d is null)
        {
            MessageBox.Show("Выберите устройство в таблице.");
            return;
        }

        Log1("--- Демо ООП ---");
        Log1($"ToString(): {d}");
        Log1($"GetHashCode(): {d.GetHashCode()}");
        Log1($"GetStatus() (virtual/override): {d.GetStatus()}");
        Log1($"CalculatePowerConsumption() (abstract/override): {d.CalculatePowerConsumption():0.##} Вт");

        IExportable exportable = d; // явная реализация доступна только через интерфейс
        Log1($"((IExportable)d).GetExportData(): {exportable.GetExportData()}  (вызов d.GetExportData() не компилируется)");

        Device asBase = d;
        string viaDerived = d switch
        {
            SmartSensor s => s.GetShortInfo(),
            SmartActuator a => a.GetShortInfo(),
            _ => asBase.GetShortInfo()
        };
        Log1($"Shadowing (new): через ссылку Device -> {asBase.GetShortInfo()}");
        Log1($"Shadowing (new): через ссылку наследника -> {viaDerived}");
    }

    private async void OnAddDeviceClick(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_txtModel.Text))
        {
            MessageBox.Show("Введите модель устройства.");
            return;
        }
        if (_cmbRoom.SelectedItem is not Room room) return;

        try
        {
            Device device = DeviceFactory.Create((string)_cmbType.SelectedItem!, 0,
                _txtModel.Text.Trim(), (double)_numPower.Value, room.Id);
            IRepository<Device> repository = _deviceRepo;
            repository.Add(device);
            Log1($"Добавлено в БД: {device.Model} ({_cmbType.SelectedItem}), комната {room.Title}");
            _txtModel.Clear();
            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось добавить устройство: " + ex.Message);
        }
    }

    // ==================================================================
    // Вкладка 2: асинхронность, события, делегаты
    // ==================================================================
    private void AddEvent(string text)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => AddEvent(text)));
            return;
        }
        _lstEvents.Items.Add(text);
        _lstEvents.TopIndex = _lstEvents.Items.Count - 1;
    }

    private void OnDeviceStatusChanged(object? sender, DeviceEventArgs e)
    {
        AddEvent($"[{e.Timestamp:HH:mm:ss}] {e.Message}");
    }

    private void OnSubscribeChanged(object? sender, EventArgs e)
    {
        foreach (Device d in _devices)
        {
            d.StatusChanged -= OnDeviceStatusChanged;
            if (_chkSubscribe.Checked)
                d.StatusChanged += OnDeviceStatusChanged;
        }
        AddEvent(_chkSubscribe.Checked ? "Подписка на события включена" : "Подписка на события отключена");
    }

    private async void OnPollClick(object? sender, EventArgs e)
    {
        List<Device> sensors = _devices.Where(d => d is SmartSensor).ToList();
        if (sensors.Count == 0) return;

        _btnPoll.Enabled = false;
        AddEvent($"Запуск параллельного опроса датчиков: {sensors.Count} шт.");
        try
        {
            var sw = Stopwatch.StartNew();
            string[] results = await _sensorService.PollAllAsync(sensors); // Task.WhenAll
            sw.Stop();

            foreach (string r in results)
                AddEvent("Результат: " + r);
            AddEvent($"Опрос завершён за {sw.ElapsedMilliseconds} мс (датчики опрашивались параллельно)");
            RefreshDevices();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка опроса: " + ex.Message);
        }
        finally
        {
            _btnPoll.Enabled = true;
        }
    }

    private async void OnSummaryClick(object? sender, EventArgs e)
    {
        if (_cmbSensors.SelectedItem is not Device sensor) return;

        ValueTask<string> pending = _sensorService.GetDeviceSummaryAsync(sensor.Id);
        bool fromCache = pending.IsCompletedSuccessfully;
        string summary = await pending;
        string source = fromCache ? "из кэша, синхронно" : "из БД, асинхронно";
        AddEvent($"Сводка {sensor.Model} (Id {sensor.Id}) [{source}]: {summary}");
    }

    private void OnCriticalClick(object? sender, EventArgs e)
    {
        double threshold = (double)_numThreshold.Value;
        AddEvent($"Поиск критических устройств (порог {threshold:0.##} Вт):");
        List<Device> critical = DeviceDelegates.FindCritical(_devices, threshold, AddEvent);
        if (critical.Count == 0)
            AddEvent("Критических устройств нет");
    }

    // ==================================================================
    // Вкладка 3: LINQ-аналитика
    // ==================================================================
    private void ShowResult(string title, IEnumerable<string> lines)
    {
        _txtLog3.Text = title + Environment.NewLine + string.Join(Environment.NewLine, lines);
    }

    private void OnJoinClick(object? sender, EventArgs e)
    {
        _report = LinqAnalytics.BuildReport(_rooms, _devices);
        _gridReport.DataSource = _report.ToList();
        _txtLog3.Text = $"Join Devices + Rooms -> DeviceReportDto: {_report.Count} записей.";
    }

    private void OnFilterSortClick(object? sender, EventArgs e)
    {
        double min = (double)_numMinPower.Value;
        List<DeviceReportDto> result = LinqAnalytics.FilterSort(_report, min);
        _gridReport.DataSource = result;
        _txtLog3.Text = $"Where(Power >= {min:0.##}).OrderBy(Floor).ThenByDescending(Power): {result.Count} записей.";
    }

    private void OnGroupJoinClick(object? sender, EventArgs e) =>
        ShowResult("GroupJoin:", LinqAnalytics.GroupJoinSummary(_rooms, _devices, _logs));

    private void OnGroupByClick(object? sender, EventArgs e) =>
        ShowResult("GroupBy(RoomTitle): Count, Sum, Average, Aggregate", LinqAnalytics.GroupStats(_report));

    private void OnQuantifiersClick(object? sender, EventArgs e) =>
        ShowResult("Квантификаторы:", LinqAnalytics.QuantifierChecks(_report, (double)_numMinPower.Value));

    private void OnDeferredClick(object? sender, EventArgs e) =>
        ShowResult("Отложенное выполнение vs немедленная материализация:",
            LinqAnalytics.DeferredVsMaterialized(_report, (double)_numMinPower.Value));

    // ==================================================================
    // Вкладка 4: множества и пагинация
    // ==================================================================
    private void OnCompareClick(object? sender, EventArgs e)
    {
        if (_cmbRoomA.SelectedItem is not string a || _cmbRoomB.SelectedItem is not string b) return;
        _txtLog4.Text = $"Сравнение комнат \"{a}\" и \"{b}\" по моделям устройств:" + Environment.NewLine +
                        string.Join(Environment.NewLine, LinqAnalytics.CompareRooms(_report, a, b));
    }

    private void ShowPage()
    {
        int pageSize = (int)_numPageSize.Value;
        int totalPages = Math.Max(1, (int)Math.Ceiling(_sortedReport.Count / (double)pageSize));
        _page = Math.Clamp(_page, 1, totalPages);
        _gridPage.DataSource = LinqAnalytics.GetPage(_sortedReport, _page, pageSize); // Skip/Take
        _lblPage.Text = $"Страница {_page} из {totalPages}";
    }
}
