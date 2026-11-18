namespace SmartHomeMaster.Models;

public class SmartActuator : Device
{
    public double LoadCapacity { get; private set; }

    public SmartActuator(int id, string model, double power, int roomId, Calibration calibration, double loadCapacity = 80)
        : base(id, model, power, roomId, calibration)
    {
        LoadCapacity = loadCapacity;
    }

    public override string GetStatus() => $"{base.GetStatus()}, нагрузка {LoadCapacity:0.##}%";

    public override double CalculatePowerConsumption() =>
        _isActive ? Power * LoadCapacity / 100.0 : Power * 0.05;

    public new string GetShortInfo() => $"[Actuator] {Model}, нагрузка {LoadCapacity:0.##}%";

    protected override Device CreateCopy(Calibration calibrationCopy) =>
        new SmartActuator(Id, Model, Power, RoomId, calibrationCopy, LoadCapacity);
}
