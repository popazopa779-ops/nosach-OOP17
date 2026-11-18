using SmartHomeMaster.Interfaces;
using SmartHomeMaster.Models;

namespace SmartHomeMaster.Data;

public class RoomRepository : IRepository<Room>
{
    private const string SelectSql = "SELECT Id, Title, Floor FROM Rooms";

    public Room GetById(int id)
    {
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = SelectSql + " WHERE Id = $id";
        cmd.Parameters.AddWithValue("$id", id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
            return new Room(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
        throw new KeyNotFoundException($"Комната с Id = {id} не найдена");
    }

    public List<Room> GetAll()
    {
        var result = new List<Room>();
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = SelectSql + " ORDER BY Id";
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
            result.Add(new Room(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
        return result;
    }

    public void Add(Room entity)
    {
        using var conn = Database.OpenConnection();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Rooms (Title, Floor) VALUES ($t, $f)";
        cmd.Parameters.AddWithValue("$t", entity.Title);
        cmd.Parameters.AddWithValue("$f", entity.Floor);
        cmd.ExecuteNonQuery();
    }

    public async Task<List<Room>> GetAllAsync()
    {
        return await Task.Run(() => GetAll());
    }
}
