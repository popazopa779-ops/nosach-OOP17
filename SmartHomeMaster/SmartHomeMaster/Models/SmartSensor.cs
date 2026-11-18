namespace SmartHomeMaster.Models;

public class SmartSensor : Device
{
    public double Accuracy { get; private set; }

    public SmartSensor(int id, string model, double power, int roomId, Calibration calibration, double accuracy = 0.5)
        : base(id, model, power, roomId, calibration)
    {
        Accuracy = accuracy;
    }

    public override string GetStatus() => $"{base.GetStatus()}, точность ±{Accuracy:0.##}";

    public override double CalculatePowerConsumption() => _isActive ? Power : Power * 0.1;

    public new string GetShortInfo() => $"[Sensor] {Model}, точность ±{Accuracy:0.##}";

    protected override Device CreateCopy(Calibration calibrationCopy) =>
        new SmartSensor(Id, Model, Power, RoomId, calibrationCopy, Accuracy);
}
