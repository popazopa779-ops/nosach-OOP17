#nullable disable
namespace SmartHomeMaster
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this._gridDevices = new System.Windows.Forms.DataGridView();
            this._txtLog1 = new System.Windows.Forms.TextBox();
            this.flowButtons1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowInput1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnDeepCopy = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnOopDemo = new System.Windows.Forms.Button();
            this.lblModel = new System.Windows.Forms.Label();
            this._txtModel = new System.Windows.Forms.TextBox();
            this.lblPower = new System.Windows.Forms.Label();
            this._numPower = new System.Windows.Forms.NumericUpDown();
            this.lblType = new System.Windows.Forms.Label();
            this._cmbType = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this._cmbRoom = new System.Windows.Forms.ComboBox();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this._lstEvents = new System.Windows.Forms.ListBox();
            this.flowTop2b = new System.Windows.Forms.FlowLayoutPanel();
            this.flowTop2a = new System.Windows.Forms.FlowLayoutPanel();
            this._chkSubscribe = new System.Windows.Forms.CheckBox();
            this._btnPoll = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lblSensor = new System.Windows.Forms.Label();
            this._cmbSensors = new System.Windows.Forms.ComboBox();
            this.btnSummary = new System.Windows.Forms.Button();
            this.lblThreshold = new System.Windows.Forms.Label();
            this._numThreshold = new System.Windows.Forms.NumericUpDown();
            this.btnCritical = new System.Windows.Forms.Button();
            this._gridReport = new System.Windows.Forms.DataGridView();
            this._txtLog3 = new System.Windows.Forms.TextBox();
            this.flowTop3b = new System.Windows.Forms.FlowLayoutPanel();
            this.flowTop3a = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMinPower = new System.Windows.Forms.Label();
            this._numMinPower = new System.Windows.Forms.NumericUpDown();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnFilterSort = new System.Windows.Forms.Button();
            this.btnGroupJoin = new System.Windows.Forms.Button();
            this.btnGroupBy = new System.Windows.Forms.Button();
            this.btnQuantifiers = new System.Windows.Forms.Button();
            this.btnDeferred = new System.Windows.Forms.Button();
            this._gridPage = new System.Windows.Forms.DataGridView();
            this._txtLog4 = new System.Windows.Forms.TextBox();
            this.flowTop4b = new System.Windows.Forms.FlowLayoutPanel();
            this.flowTop4a = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRoomA = new System.Windows.Forms.Label();
            this._cmbRoomA = new System.Windows.Forms.ComboBox();
            this.lblRoomB = new System.Windows.Forms.Label();
            this._cmbRoomB = new System.Windows.Forms.ComboBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this._lblPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageSize = new System.Windows.Forms.Label();
            this._numPageSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this._gridDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numMinPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numPageSize)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.flowButtons1.SuspendLayout();
            this.flowInput1.SuspendLayout();
            this.flowTop2b.SuspendLayout();
            this.flowTop2a.SuspendLayout();
            this.flowTop3b.SuspendLayout();
            this.flowTop3a.SuspendLayout();
            this.flowTop4b.SuspendLayout();
            this.flowTop4a.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Name = "tabControl";
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.TabIndex = 0;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            // 
            // tabPage1
            // 
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Text = "Реестр приборов (ООП & Generics)";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Controls.Add(this._gridDevices);
            this.tabPage1.Controls.Add(this._txtLog1);
            this.tabPage1.Controls.Add(this.flowButtons1);
            this.tabPage1.Controls.Add(this.flowInput1);
            // 
            // tabPage2
            // 
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Text = "Асинхронный опрос & Events";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Controls.Add(this._lstEvents);
            this.tabPage2.Controls.Add(this.flowTop2b);
            this.tabPage2.Controls.Add(this.flowTop2a);
            // 
            // tabPage3
            // 
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Text = "LINQ-Аналитика & DTO";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Controls.Add(this._gridReport);
            this.tabPage3.Controls.Add(this._txtLog3);
            this.tabPage3.Controls.Add(this.flowTop3b);
            this.tabPage3.Controls.Add(this.flowTop3a);
            // 
            // tabPage4
            // 
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Text = "Множества & Пагинация";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Controls.Add(this._gridPage);
            this.tabPage4.Controls.Add(this._txtLog4);
            this.tabPage4.Controls.Add(this.flowTop4b);
            this.tabPage4.Controls.Add(this.flowTop4a);
            // 
            // _gridDevices
            // 
            this._gridDevices.Name = "_gridDevices";
            this._gridDevices.AllowUserToAddRows = false;
            this._gridDevices.AllowUserToDeleteRows = false;
            this._gridDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridDevices.MultiSelect = false;
            this._gridDevices.ReadOnly = true;
            this._gridDevices.RowHeadersVisible = false;
            this._gridDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridDevices.TabIndex = 5;
            // 
            // _txtLog1
            // 
            this._txtLog1.Name = "_txtLog1";
            this._txtLog1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._txtLog1.Multiline = true;
            this._txtLog1.Size = new System.Drawing.Size(100, 170);
            this._txtLog1.ReadOnly = true;
            this._txtLog1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtLog1.TabIndex = 6;
            // 
            // flowButtons1
            // 
            this.flowButtons1.Name = "flowButtons1";
            this.flowButtons1.AutoSize = true;
            this.flowButtons1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowButtons1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowButtons1.Padding = new System.Windows.Forms.Padding(4);
            this.flowButtons1.WrapContents = true;
            this.flowButtons1.TabIndex = 7;
            this.flowButtons1.Controls.Add(this.btnSort);
            this.flowButtons1.Controls.Add(this.btnDeepCopy);
            this.flowButtons1.Controls.Add(this.btnToggle);
            this.flowButtons1.Controls.Add(this.btnOopDemo);
            // 
            // flowInput1
            // 
            this.flowInput1.Name = "flowInput1";
            this.flowInput1.AutoSize = true;
            this.flowInput1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowInput1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowInput1.Padding = new System.Windows.Forms.Padding(4);
            this.flowInput1.WrapContents = true;
            this.flowInput1.TabIndex = 8;
            this.flowInput1.Controls.Add(this.lblModel);
            this.flowInput1.Controls.Add(this._txtModel);
            this.flowInput1.Controls.Add(this.lblPower);
            this.flowInput1.Controls.Add(this._numPower);
            this.flowInput1.Controls.Add(this.lblType);
            this.flowInput1.Controls.Add(this._cmbType);
            this.flowInput1.Controls.Add(this.lblRoom);
            this.flowInput1.Controls.Add(this._cmbRoom);
            this.flowInput1.Controls.Add(this.btnAddDevice);
            // 
            // btnSort
            // 
            this.btnSort.Name = "btnSort";
            this.btnSort.AutoSize = true;
            this.btnSort.Margin = new System.Windows.Forms.Padding(4);
            this.btnSort.Text = "Сортировка по мощности (IComparable)";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.TabIndex = 9;
            this.btnSort.Click += new System.EventHandler(this.OnSortClick);
            // 
            // btnDeepCopy
            // 
            this.btnDeepCopy.Name = "btnDeepCopy";
            this.btnDeepCopy.AutoSize = true;
            this.btnDeepCopy.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeepCopy.Text = "Deep Copy (ICloneable)";
            this.btnDeepCopy.UseVisualStyleBackColor = true;
            this.btnDeepCopy.TabIndex = 10;
            this.btnDeepCopy.Click += new System.EventHandler(this.OnDeepCopyClick);
            // 
            // btnToggle
            // 
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.AutoSize = true;
            this.btnToggle.Margin = new System.Windows.Forms.Padding(4);
            this.btnToggle.Text = "Вкл/Выкл выбранное";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.TabIndex = 11;
            this.btnToggle.Click += new System.EventHandler(this.OnToggleClick);
            // 
            // btnOopDemo
            // 
            this.btnOopDemo.Name = "btnOopDemo";
            this.btnOopDemo.AutoSize = true;
            this.btnOopDemo.Margin = new System.Windows.Forms.Padding(4);
            this.btnOopDemo.Text = "Демо ООП (Equals, new, IExportable)";
            this.btnOopDemo.UseVisualStyleBackColor = true;
            this.btnOopDemo.TabIndex = 12;
            this.btnOopDemo.Click += new System.EventHandler(this.OnOopDemoClick);
            // 
            // lblModel
            // 
            this.lblModel.Name = "lblModel";
            this.lblModel.AutoSize = true;
            this.lblModel.Margin = new System.Windows.Forms.Padding(8, 9, 2, 0);
            this.lblModel.Text = "Модель:";
            this.lblModel.TabIndex = 13;
            // 
            // _txtModel
            // 
            this._txtModel.Name = "_txtModel";
            this._txtModel.Size = new System.Drawing.Size(140, 23);
            this._txtModel.TabIndex = 14;
            // 
            // lblPower
            // 
            this.lblPower.Name = "lblPower";
            this.lblPower.AutoSize = true;
            this.lblPower.Margin = new System.Windows.Forms.Padding(8, 9, 2, 0);
            this.lblPower.Text = "Мощность, Вт:";
            this.lblPower.TabIndex = 15;
            // 
            // _numPower
            // 
            this._numPower.Name = "_numPower";
            this._numPower.Size = new System.Drawing.Size(80, 23);
            this._numPower.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            this._numPower.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            this._numPower.Value = new decimal(new int[] { 10, 0, 0, 0 });
            this._numPower.DecimalPlaces = 1;
            this._numPower.TabIndex = 16;
            // 
            // lblType
            // 
            this.lblType.Name = "lblType";
            this.lblType.AutoSize = true;
            this.lblType.Margin = new System.Windows.Forms.Padding(8, 9, 2, 0);
            this.lblType.Text = "Тип:";
            this.lblType.TabIndex = 17;
            // 
            // _cmbType
            // 
            this._cmbType.Name = "_cmbType";
            this._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbType.FormattingEnabled = true;
            this._cmbType.Size = new System.Drawing.Size(100, 23);
            this._cmbType.Items.AddRange(new object[] { "Sensor", "Actuator" });
            this._cmbType.SelectedIndex = 0;
            this._cmbType.TabIndex = 18;
            // 
            // lblRoom
            // 
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.AutoSize = true;
            this.lblRoom.Margin = new System.Windows.Forms.Padding(8, 9, 2, 0);
            this.lblRoom.Text = "Комната:";
            this.lblRoom.TabIndex = 19;
            // 
            // _cmbRoom
            // 
            this._cmbRoom.Name = "_cmbRoom";
            this._cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbRoom.FormattingEnabled = true;
            this._cmbRoom.Size = new System.Drawing.Size(160, 23);
            this._cmbRoom.TabIndex = 20;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.AutoSize = true;
            this.btnAddDevice.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDevice.Text = "Добавить в БД";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.TabIndex = 21;
            this.btnAddDevice.Click += new System.EventHandler(this.OnAddDeviceClick);
            // 
            // _lstEvents
            // 
            this._lstEvents.Name = "_lstEvents";
            this._lstEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lstEvents.FormattingEnabled = true;
            this._lstEvents.HorizontalScrollbar = true;
            this._lstEvents.TabIndex = 22;
            // 
            // flowTop2b
            // 
            this.flowTop2b.Name = "flowTop2b";
            this.flowTop2b.AutoSize = true;
            this.flowTop2b.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowTop2b.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowTop2b.Padding = new System.Windows.Forms.Padding(4);
            this.flowTop2b.WrapContents = true;
            this.flowTop2b.TabIndex = 23;
            this.flowTop2b.Controls.Add(this.lblSensor);
            this.flowTop2b.Controls.Add(this._cmbSensors);
            this.flowTop2b.Controls.Add(this.btnSummary);
            this.flowTop2b.Controls.Add(this.lblThreshold);
            this.flowTop2b.Controls.Add(this._numThreshold);
            this.flowTop2b.Controls.Add(this.btnCritical);
            // 
            // flowTop2a
            // 
            this.flowTop2a.Name = "flowTop2a";
            this.flowTop2a.AutoSize = true;
            this.flowTop2a.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowTop2a.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowTop2a.Padding = new System.Windows.Forms.Padding(4);
            this.flowTop2a.WrapContents = true;
            this.flowTop2a.TabIndex = 24;
            this.flowTop2a.Controls.Add(this._chkSubscribe);
            this.flowTop2a.Controls.Add(this._btnPoll);
            this.flowTop2a.Controls.Add(this.btnClearLog);
            // 
            // _chkSubscribe
            // 
            this._chkSubscribe.Name = "_chkSubscribe";
            this._chkSubscribe.AutoSize = true;
            this._chkSubscribe.Checked = true;
            this._chkSubscribe.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkSubscribe.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this._chkSubscribe.Text = "Подписка на события StatusChanged";
            this._chkSubscribe.UseVisualStyleBackColor = true;
            this._chkSubscribe.TabIndex = 25;
            this._chkSubscribe.CheckedChanged += new System.EventHandler(this.OnSubscribeChanged);
            // 
            // _btnPoll
            // 
            this._btnPoll.Name = "_btnPoll";
            this._btnPoll.AutoSize = true;
            this._btnPoll.Margin = new System.Windows.Forms.Padding(4);
            this._btnPoll.Text = "Запустить опрос датчиков (Task.WhenAll)";
            this._btnPoll.UseVisualStyleBackColor = true;
            this._btnPoll.TabIndex = 26;
            this._btnPoll.Click += new System.EventHandler(this.OnPollClick);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.AutoSize = true;
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLog.Text = "Очистить журнал";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.TabIndex = 27;
            this.btnClearLog.Click += new System.EventHandler(this.OnClearLogClick);
            // 
            // lblSensor
            // 
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.AutoSize = true;
            this.lblSensor.Margin = new System.Windows.Forms.Padding(8, 9, 2, 0);
            this.lblSensor.Text = "Датчик:";
            this.lblSensor.TabIndex = 28;
            // 
            // _cmbSensors
            // 
            this._cmbSensors.Name = "_cmbSensors";
            this._cmbSensors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbSensors.FormattingEnabled = true;
            this._cmbSensors.Size = new System.Drawing.Size(160, 23);
            this._cmbSensors.TabIndex = 29;
            // 
            // btnSummary
            // 
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.AutoSize = true;
            this.btnSummary.Margin = new System.Windows.Forms.Padding(4);
            this.btnSummary.Text = "Сводка (ValueTask)";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.TabIndex = 30;
            this.btnSummary.Click += new System.EventHandler(this.OnSummaryClick);
            // 
            // lblThreshold
            // 
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Margin = new System.Windows.Forms.Padding(8, 9, 2, 0);
            this.lblThreshold.Text = "Порог потребления, Вт:";
            this.lblThreshold.TabIndex = 31;
            // 
            // _numThreshold
            // 
            this._numThreshold.Name = "_numThreshold";
            this._numThreshold.Size = new System.Drawing.Size(80, 23);
            this._numThreshold.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this._numThreshold.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            this._numThreshold.Value = new decimal(new int[] { 100, 0, 0, 0 });
            this._numThreshold.TabIndex = 32;
            // 
            // btnCritical
            // 
            this.btnCritical.Name = "btnCritical";
            this.btnCritical.AutoSize = true;
            this.btnCritical.Margin = new System.Windows.Forms.Padding(4);
            this.btnCritical.Text = "Критические устройства (Predicate/Func)";
            this.btnCritical.UseVisualStyleBackColor = true;
            this.btnCritical.TabIndex = 33;
            this.btnCritical.Click += new System.EventHandler(this.OnCriticalClick);
            // 
            // _gridReport
            // 
            this._gridReport.Name = "_gridReport";
            this._gridReport.AllowUserToAddRows = false;
            this._gridReport.AllowUserToDeleteRows = false;
            this._gridReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridReport.MultiSelect = false;
            this._gridReport.ReadOnly = true;
            this._gridReport.RowHeadersVisible = false;
            this._gridReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridReport.TabIndex = 34;
            // 
            // _txtLog3
            // 
            this._txtLog3.Name = "_txtLog3";
            this._txtLog3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._txtLog3.Multiline = true;
            this._txtLog3.Size = new System.Drawing.Size(100, 210);
            this._txtLog3.ReadOnly = true;
            this._txtLog3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtLog3.TabIndex = 35;
            // 
            // flowTop3b
            // 
            this.flowTop3b.Name = "flowTop3b";
            this.flowTop3b.AutoSize = true;
            this.flowTop3b.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowTop3b.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowTop3b.Padding = new System.Windows.Forms.Padding(4);
            this.flowTop3b.WrapContents = true;
            this.flowTop3b.TabIndex = 36;
            this.flowTop3b.Controls.Add(this.btnGroupBy);
            this.flowTop3b.Controls.Add(this.btnQuantifiers);
            this.flowTop3b.Controls.Add(this.btnDeferred);
            // 
            // flowTop3a
            // 
            this.flowTop3a.Name = "flowTop3a";
            this.flowTop3a.AutoSize = true;
            this.flowTop3a.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowTop3a.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowTop3a.Padding = new System.Windows.Forms.Padding(4);
            this.flowTop3a.WrapContents = true;
            this.flowTop3a.TabIndex = 37;
            this.flowTop3a.Controls.Add(this.lblMinPower);
            this.flowTop3a.Controls.Add(this._numMinPower);
            this.flowTop3a.Controls.Add(this.btnJoin);
            this.flowTop3a.Controls.Add(this.btnFilterSort);
            this.flowTop3a.Controls.Add(this.btnGroupJoin);
            // 
            // lblMinPower
            // 
            this.lblMinPower.Name = "lblMinPower";
            this.lblMinPower.AutoSize = true;
            this.lblMinPower.Margin = new System.Windows.Forms.Padding(8, 9, 2, 0);
            this.lblMinPower.Text = "Мощность, Вт (порог):";
            this.lblMinPower.TabIndex = 38;
            // 
            // _numMinPower
            // 
            this._numMinPower.Name = "_numMinPower";
            this._numMinPower.Size = new System.Drawing.Size(80, 23);
            this._numMinPower.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this._numMinPower.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            this._numMinPower.Value = new decimal(new int[] { 50, 0, 0, 0 });
            this._numMinPower.TabIndex = 39;
            // 
            // btnJoin
            // 
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.AutoSize = true;
            this.btnJoin.Margin = new System.Windows.Forms.Padding(4);
            this.btnJoin.Text = "Join -> DTO";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.TabIndex = 40;
            this.btnJoin.Click += new System.EventHandler(this.OnJoinClick);
            // 
            // btnFilterSort
            // 
            this.btnFilterSort.Name = "btnFilterSort";
            this.btnFilterSort.AutoSize = true;
            this.btnFilterSort.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilterSort.Text = "Фильтр + сортировка";
            this.btnFilterSort.UseVisualStyleBackColor = true;
            this.btnFilterSort.TabIndex = 41;
            this.btnFilterSort.Click += new System.EventHandler(this.OnFilterSortClick);
            // 
            // btnGroupJoin
            // 
            this.btnGroupJoin.Name = "btnGroupJoin";
            this.btnGroupJoin.AutoSize = true;
            this.btnGroupJoin.Margin = new System.Windows.Forms.Padding(4);
            this.btnGroupJoin.Text = "GroupJoin";
            this.btnGroupJoin.UseVisualStyleBackColor = true;
            this.btnGroupJoin.TabIndex = 42;
            this.btnGroupJoin.Click += new System.EventHandler(this.OnGroupJoinClick);
            // 
            // btnGroupBy
            // 
            this.btnGroupBy.Name = "btnGroupBy";
            this.btnGroupBy.AutoSize = true;
            this.btnGroupBy.Margin = new System.Windows.Forms.Padding(4);
            this.btnGroupBy.Text = "GroupBy + агрегаты";
            this.btnGroupBy.UseVisualStyleBackColor = true;
            this.btnGroupBy.TabIndex = 43;
            this.btnGroupBy.Click += new System.EventHandler(this.OnGroupByClick);
            // 
            // btnQuantifiers
            // 
            this.btnQuantifiers.Name = "btnQuantifiers";
            this.btnQuantifiers.AutoSize = true;
            this.btnQuantifiers.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuantifiers.Text = "Any / All / FirstOrDefault";
            this.btnQuantifiers.UseVisualStyleBackColor = true;
            this.btnQuantifiers.TabIndex = 44;
            this.btnQuantifiers.Click += new System.EventHandler(this.OnQuantifiersClick);
            // 
            // btnDeferred
            // 
            this.btnDeferred.Name = "btnDeferred";
            this.btnDeferred.AutoSize = true;
            this.btnDeferred.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeferred.Text = "Отложенное выполнение vs ToList()";
            this.btnDeferred.UseVisualStyleBackColor = true;
            this.btnDeferred.TabIndex = 45;
            this.btnDeferred.Click += new System.EventHandler(this.OnDeferredClick);
            // 
            // _gridPage
            // 
            this._gridPage.Name = "_gridPage";
            this._gridPage.AllowUserToAddRows = false;
            this._gridPage.AllowUserToDeleteRows = false;
            this._gridPage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridPage.MultiSelect = false;
            this._gridPage.ReadOnly = true;
            this._gridPage.RowHeadersVisible = false;
            this._gridPage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridPage.TabIndex = 46;
            // 
            // _txtLog4
            // 
            this._txtLog4.Name = "_txtLog4";
            this._txtLog4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._txtLog4.Multiline = true;
            this._txtLog4.Size = new System.Drawing.Size(100, 120);
            this._txtLog4.ReadOnly = true;
            this._txtLog4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtLog4.TabIndex = 47;
            // 
            // flowTop4b
            // 
            this.flowTop4b.Name = "flowTop4b";
            this.flowTop4b.AutoSize = true;
            this.flowTop4b.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowTop4b.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowTop4b.Padding = new System.Windows.Forms.Padding(4);
            this.flowTop4b.WrapContents = true;
            this.flowTop4b.TabIndex = 48;
            this.flowTop4b.Controls.Add(this.btnPrev);
            this.flowTop4b.Controls.Add(this._lblPage);
            this.flowTop4b.Controls.Add(this.btnNext);
            this.flowTop4b.Controls.Add(this.lblPageSize);
            this.flowTop4b.Controls.Add(this._numPageSize);
            // 
            // flowTop4a
            // 
            this.flowTop4a.Name = "flowTop4a";
            this.flowTop4a.AutoSize = true;
            this.flowTop4a.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowTop4a.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowTop4a.Padding = new System.Windows.Forms.Padding(4);
            this.flowTop4a.WrapContents = true;
            this.flowTop4a.TabIndex = 49;
            this.flowTop4a.Controls.Add(this.lblRoomA);
            this.flowTop4a.Controls.Add(this._cmbRoomA);
            this.flowTop4a.Controls.Add(this.lblRoomB);
            this.flowTop4a.Controls.Add(this._cmbRoomB);
            this.flowTop4a.Controls.Add(this.btnCompare);
            // 
            // lblRoomA
            // 
            this.lblRoomA.Name = "lblRoomA";
            this.lblRoomA.AutoSize = true;
            this.lblRoomA.Margin = new System.Windows.Forms.Padding(8, 9, 2, 0);
            this.lblRoomA.Text = "Комната A:";
            this.lblRoomA.TabIndex = 50;
            // 
            // _cmbRoomA
            // 
            this._cmbRoomA.Name = "_cmbRoomA";
            this._cmbRoomA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbRoomA.FormattingEnabled = true;
            this._cmbRoomA.Size = new System.Drawing.Size(130, 23);
            this._cmbRoomA.TabIndex = 51;
            // 
            // lblRoomB
            // 
            this.lblRoomB.Name = "lblRoomB";
            this.lblRoomB.AutoSize = true;
            this.lblRoomB.Margin = new System.Windows.Forms.Padding(8, 9, 2, 0);
            this.lblRoomB.Text = "Комната B:";
            this.lblRoomB.TabIndex = 52;
            // 
            // _cmbRoomB
            // 
            this._cmbRoomB.Name = "_cmbRoomB";
            this._cmbRoomB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbRoomB.FormattingEnabled = true;
            this._cmbRoomB.Size = new System.Drawing.Size(130, 23);
            this._cmbRoomB.TabIndex = 53;
            // 
            // btnCompare
            // 
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.AutoSize = true;
            this.btnCompare.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompare.Text = "Сравнить (Intersect/Except/Union)";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.TabIndex = 54;
            this.btnCompare.Click += new System.EventHandler(this.OnCompareClick);
            // 
            // btnPrev
            // 
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.AutoSize = true;
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrev.Text = "< Назад";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.TabIndex = 55;
            this.btnPrev.Click += new System.EventHandler(this.OnPrevPageClick);
            // 
            // _lblPage
            // 
            this._lblPage.Name = "_lblPage";
            this._lblPage.AutoSize = true;
            this._lblPage.Margin = new System.Windows.Forms.Padding(8, 9, 8, 0);
            this._lblPage.Text = "Страница 1 из 1";
            this._lblPage.TabIndex = 56;
            // 
            // btnNext
            // 
            this.btnNext.Name = "btnNext";
            this.btnNext.AutoSize = true;
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Text = "Вперёд >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.TabIndex = 57;
            this.btnNext.Click += new System.EventHandler(this.OnNextPageClick);
            // 
            // lblPageSize
            // 
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Margin = new System.Windows.Forms.Padding(8, 9, 2, 0);
            this.lblPageSize.Text = "Размер страницы:";
            this.lblPageSize.TabIndex = 58;
            // 
            // _numPageSize
            // 
            this._numPageSize.Name = "_numPageSize";
            this._numPageSize.Size = new System.Drawing.Size(60, 23);
            this._numPageSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this._numPageSize.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this._numPageSize.Value = new decimal(new int[] { 4, 0, 0, 0 });
            this._numPageSize.TabIndex = 59;
            this._numPageSize.ValueChanged += new System.EventHandler(this.OnPageSizeChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 711);
            this.Controls.Add(this.tabControl);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartHome Master Console";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.flowButtons1.ResumeLayout(false);
            this.flowInput1.ResumeLayout(false);
            this.flowTop2b.ResumeLayout(false);
            this.flowTop2a.ResumeLayout(false);
            this.flowTop3b.ResumeLayout(false);
            this.flowTop3a.ResumeLayout(false);
            this.flowTop4b.ResumeLayout(false);
            this.flowTop4a.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numMinPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numPageSize)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView _gridDevices;
        private System.Windows.Forms.TextBox _txtLog1;
        private System.Windows.Forms.FlowLayoutPanel flowButtons1;
        private System.Windows.Forms.FlowLayoutPanel flowInput1;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnDeepCopy;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnOopDemo;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox _txtModel;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.NumericUpDown _numPower;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox _cmbType;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox _cmbRoom;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.ListBox _lstEvents;
        private System.Windows.Forms.FlowLayoutPanel flowTop2b;
        private System.Windows.Forms.FlowLayoutPanel flowTop2a;
        private System.Windows.Forms.CheckBox _chkSubscribe;
        private System.Windows.Forms.Button _btnPoll;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.ComboBox _cmbSensors;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.NumericUpDown _numThreshold;
        private System.Windows.Forms.Button btnCritical;
        private System.Windows.Forms.DataGridView _gridReport;
        private System.Windows.Forms.TextBox _txtLog3;
        private System.Windows.Forms.FlowLayoutPanel flowTop3b;
        private System.Windows.Forms.FlowLayoutPanel flowTop3a;
        private System.Windows.Forms.Label lblMinPower;
        private System.Windows.Forms.NumericUpDown _numMinPower;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnFilterSort;
        private System.Windows.Forms.Button btnGroupJoin;
        private System.Windows.Forms.Button btnGroupBy;
        private System.Windows.Forms.Button btnQuantifiers;
        private System.Windows.Forms.Button btnDeferred;
        private System.Windows.Forms.DataGridView _gridPage;
        private System.Windows.Forms.TextBox _txtLog4;
        private System.Windows.Forms.FlowLayoutPanel flowTop4b;
        private System.Windows.Forms.FlowLayoutPanel flowTop4a;
        private System.Windows.Forms.Label lblRoomA;
        private System.Windows.Forms.ComboBox _cmbRoomA;
        private System.Windows.Forms.Label lblRoomB;
        private System.Windows.Forms.ComboBox _cmbRoomB;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label _lblPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.NumericUpDown _numPageSize;
    }
}
