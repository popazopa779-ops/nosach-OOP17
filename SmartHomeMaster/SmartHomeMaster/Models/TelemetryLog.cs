namespace SmartHomeMaster.Models;

public class TelemetryLog
{
    public int Id { get; }
    public int DeviceId { get; }
    public double Reading { get; }
    public string Timestamp { get; }

    public TelemetryLog(int id, int deviceId, double reading, string timestamp)
    {
        Id = id;
        DeviceId = deviceId;
        Reading = reading;
        Timestamp = timestamp;
    }
}
