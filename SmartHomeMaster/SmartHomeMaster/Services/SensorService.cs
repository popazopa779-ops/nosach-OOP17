using SmartHomeMaster.Data;
using SmartHomeMaster.Models;

namespace SmartHomeMaster.Services;

public class SensorService
{
    private readonly TelemetryRepository _telemetry;
    private readonly Dictionary<int, string> _cache = new();

    public SensorService(TelemetryRepository telemetry)
    {
        _telemetry = telemetry;
    }

    public async Task<string> PollSensorAsync(Device sensor)
    {
        await Task.Delay(Random.Shared.Next(300, 1500));
        double value = await _telemetry.GetLatestReadingAsync(sensor.Id) ?? 0;
        sensor.UpdateReading(value); // вызывает событие StatusChanged
        return $"{sensor.Model} (Id {sensor.Id}): {value:0.##}";
    }

    public async Task<string[]> PollAllAsync(IEnumerable<Device> sensors)
    {
        List<Task<string>> tasks = sensors.Select(s => PollSensorAsync(s)).ToList();
        return await Task.WhenAll(tasks);
    }

    public ValueTask<string> GetDeviceSummaryAsync(int deviceId)
    {
        if (_cache.TryGetValue(deviceId, out string? cached))
            return new ValueTask<string>(cached);

        return new ValueTask<string>(LoadSummaryAsync(deviceId));
    }

    private async Task<string> LoadSummaryAsync(int deviceId)
    {
        List<TelemetryLog> logs = await _telemetry.GetByDeviceAsync(deviceId);
        string summary = logs.Count == 0
            ? "нет данных"
            : $"показаний {logs.Count}, среднее {logs.Average(l => l.Reading):0.##}, максимум {logs.Max(l => l.Reading):0.##}";
        _cache[deviceId] = summary;
        return summary;
    }
}
