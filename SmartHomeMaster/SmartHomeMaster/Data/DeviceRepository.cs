using SmartHomeMaster.Interfaces;
using SmartHomeMaster.Models;

namespace SmartHomeMaster.Data;

public class DeviceRepository : IRepository<Device>
{
    private const string SelectSql = "SELECT Id, RoomId, Model, Power, Type FROM Devices";

    private static Device Map(Microsoft.Data.Sqlite.SqliteDataReader reader) =>
        DeviceFactory.Create(reader.GetString(4), reader.GetInt32(0), reader.GetString(2),
            reader.GetDouble(3), reader.GetInt32(1));

    public Device GetById(int id)
    {
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = SelectSql + " WHERE Id = $id";
        cmd.Parameters.AddWithValue("$id", id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
            return Map(reader);
        throw new KeyNotFoundException($"Устройство с Id = {id} не найдено");
    }

    public List<Device> GetAll()
    {
        var result = new List<Device>();
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = SelectSql + " ORDER BY Id";
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
            result.Add(Map(reader));
        return result;
    }

    public void Add(Device entity)
    {
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Devices (RoomId, Model, Power, Type) VALUES ($r, $m, $p, $t)";
        cmd.Parameters.AddWithValue("$r", entity.RoomId);
        cmd.Parameters.AddWithValue("$m", entity.Model);
        cmd.Parameters.AddWithValue("$p", entity.Power);
        cmd.Parameters.AddWithValue("$t", DeviceFactory.GetTypeName(entity));
        cmd.ExecuteNonQuery();
    }

    public async Task<List<Device>> GetAllAsync()
    {
        return await Task.Run(() => GetAll());
    }
}
