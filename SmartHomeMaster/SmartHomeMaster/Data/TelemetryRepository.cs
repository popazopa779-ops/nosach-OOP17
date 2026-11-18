using SmartHomeMaster.Interfaces;
using SmartHomeMaster.Models;

namespace SmartHomeMaster.Data;

public class TelemetryRepository : IRepository<TelemetryLog>
{
    private const string SelectSql = "SELECT Id, DeviceId, Reading, Timestamp FROM TelemetryLogs";

    private static TelemetryLog Map(Microsoft.Data.Sqlite.SqliteDataReader reader) =>
        new TelemetryLog(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3));

    public TelemetryLog GetById(int id)
    {
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = SelectSql + " WHERE Id = $id";
        cmd.Parameters.AddWithValue("$id", id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
            return Map(reader);
        throw new KeyNotFoundException($"Запись журнала с Id = {id} не найдена");
    }

    public List<TelemetryLog> GetAll()
    {
        var result = new List<TelemetryLog>();
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = SelectSql + " ORDER BY Id";
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
            result.Add(Map(reader));
        return result;
    }

    public void Add(TelemetryLog entity)
    {
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO TelemetryLogs (DeviceId, Reading, Timestamp) VALUES ($d, $r, $t)";
        cmd.Parameters.AddWithValue("$d", entity.DeviceId);
        cmd.Parameters.AddWithValue("$r", entity.Reading);
        cmd.Parameters.AddWithValue("$t", entity.Timestamp);
        cmd.ExecuteNonQuery();
    }

    public List<TelemetryLog> GetByDevice(int deviceId)
    {
        var result = new List<TelemetryLog>();
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = SelectSql + " WHERE DeviceId = $d ORDER BY Timestamp DESC";
        cmd.Parameters.AddWithValue("$d", deviceId);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
            result.Add(Map(reader));
        return result;
    }

    public double? GetLatestReading(int deviceId)
    {
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT Reading FROM TelemetryLogs WHERE DeviceId = $d ORDER BY Timestamp DESC, Id DESC LIMIT 1";
        cmd.Parameters.AddWithValue("$d", deviceId);
        object? value = cmd.ExecuteScalar();
        if (value is null || value is DBNull) return null;
        return Convert.ToDouble(value);
    }

    public async Task<List<TelemetryLog>> GetAllAsync() => await Task.Run(() => GetAll());

    public async Task<List<TelemetryLog>> GetByDeviceAsync(int deviceId) =>
        await Task.Run(() => GetByDevice(deviceId));

    public async Task<double?> GetLatestReadingAsync(int deviceId) =>
        await Task.Run(() => GetLatestReading(deviceId));
}
