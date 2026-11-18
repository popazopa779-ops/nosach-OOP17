using SmartHomeMaster.Interfaces;

namespace SmartHomeMaster.Models;
public abstract class Device : IComparable<Device>, ICloneable, IExportable
{
    protected bool _isActive;

    public int Id { get; private set; }
    public string Model { get; private set; }
    public double Power { get; private set; }
    public int RoomId { get; private set; }
    public Calibration Calibration { get; private set; }
    public double? LastReading { get; private set; }

    public event EventHandler<DeviceEventArgs>? StatusChanged;

    protected Device(int id, string model, double power, int roomId, Calibration calibration)
    {
        Id = id;
        Model = model;
        Power = power;
        RoomId = roomId;
        Calibration = calibration;
        _isActive = true;
    }

    public bool IsActive => _isActive;

    public void SetActive(bool active)
    {
        if (_isActive == active) return;
        _isActive = active;
        OnStatusChanged($"{Model} (Id {Id}): {(active ? "включено" : "выключено")}");
    }

    public void UpdateReading(double value)
    {
        LastReading = value;
        OnStatusChanged($"{Model} (Id {Id}): получено показание {value:0.##}");
    }

    protected virtual void OnStatusChanged(string message)
    {
        StatusChanged?.Invoke(this, new DeviceEventArgs(message));
    }

    public virtual string GetStatus() => _isActive ? "Активно" : "Неактивно";

    public abstract double CalculatePowerConsumption();

    public string GetShortInfo() => $"[Device] {Model}";

    public override string ToString() =>
        $"{GetType().Name} #{Id} \"{Model}\", мощность {Power:0.##} Вт, статус: {GetStatus()}";

    public override bool Equals(object? obj) =>
        obj is Device other && other.Id == Id && other.Model == Model;

    public override int GetHashCode() => HashCode.Combine(Id, Model);

    public int CompareTo(Device? other) => other is null ? 1 : Power.CompareTo(other.Power);

    string IExportable.GetExportData() => $"{Id};{Model};{Power};{Calibration.PassportNumber}";

    public object Clone()
    {
        Device copy = CreateCopy((Calibration)Calibration.Clone());
        copy._isActive = _isActive;
        copy.LastReading = LastReading;
        return copy;
    }

    protected abstract Device CreateCopy(Calibration calibrationCopy);
}
