namespace SmartHomeMaster.Models;

public static class DeviceFactory
{
    public static Device Create(string type, int id, string model, double power, int roomId)
    {
        var calibration = new Calibration($"PASS-{id:D4}", 0.0, DateTime.Today);
        return type switch
        {
            "Sensor" => new SmartSensor(id, model, power, roomId, calibration),
            "Actuator" => new SmartActuator(id, model, power, roomId, calibration),
            _ => throw new ArgumentException($"Неизвестный тип устройства: {type}", nameof(type))
        };
    }

    public static string GetTypeName(Device device) => device switch
    {
        SmartSensor => "Sensor",
        SmartActuator => "Actuator",
        _ => "Unknown"
    };
}
