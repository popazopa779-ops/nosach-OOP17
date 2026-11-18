using Microsoft.Data.Sqlite;

namespace SmartHomeMaster.Data;

public static class Database
{
    public static string DbPath { get; } = Path.Combine(AppContext.BaseDirectory, "smart_home.db");

    private static string ConnectionString =>
        new SqliteConnectionStringBuilder { DataSource = DbPath }.ToString();

    public static SqliteConnection OpenConnection()
    {
        var conn = new SqliteConnection(ConnectionString);
        conn.Open();
        using var pragma = conn.CreateCommand();
        pragma.CommandText = "PRAGMA foreign_keys = ON;";
        pragma.ExecuteNonQuery();
        return conn;
    }

    public static void Initialize()
    {
        using var conn = OpenConnection();

        Exec(conn, null, @"CREATE TABLE IF NOT EXISTS Rooms (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL UNIQUE,
                Floor INTEGER NOT NULL)");
        Exec(conn, null, @"CREATE TABLE IF NOT EXISTS Devices (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                RoomId INTEGER NOT NULL,
                Model TEXT NOT NULL,
                Power REAL NOT NULL,
                Type TEXT NOT NULL,
                FOREIGN KEY (RoomId) REFERENCES Rooms(Id))");
        Exec(conn, null, @"CREATE TABLE IF NOT EXISTS TelemetryLogs (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                DeviceId INTEGER NOT NULL,
                Reading REAL NOT NULL,
                Timestamp TEXT NOT NULL,
                FOREIGN KEY (DeviceId) REFERENCES Devices(Id))");

        using var countCmd = conn.CreateCommand();
        countCmd.CommandText = "SELECT COUNT(*) FROM Rooms";
        if (Convert.ToInt32(countCmd.ExecuteScalar()) == 0)
            Seed(conn);
    }

    private static void Seed(SqliteConnection conn)
    {
        var rooms = new (string Title, int Floor)[]
        {
            ("Гостиная", 1), ("Кухня", 1), ("Спальня", 2), ("Кабинет", 2), ("Гараж", 0)
        };

        var devices = new (int RoomId, string Model, double Power, string Type)[]
        {
            (1, "Thermo-X1", 5.5, "Sensor"),
            (1, "Lumen L200", 60, "Actuator"),
            (1, "Motion-M3", 3, "Sensor"),
            (2, "Gas-Guard G7", 4, "Sensor"),
            (2, "Fridge-Link F9", 150, "Actuator"),
            (2, "Lumen L200", 60, "Actuator"),
            (3, "Thermo-X1", 5.5, "Sensor"),
            (3, "Blind-Drive B5", 45, "Actuator"),
            (3, "Humid-H2", 2.5, "Sensor"),
            (4, "Motion-M3", 3, "Sensor"),
            (4, "Lumen L200", 60, "Actuator"),
            (4, "Air-Pro A8", 120, "Actuator"),
            (5, "Door-Motor D12", 300, "Actuator"),
            (5, "Smoke-S1", 1.5, "Sensor")
        };

        using var tx = conn.BeginTransaction();

        foreach (var r in rooms)
            Exec(conn, tx, "INSERT INTO Rooms (Title, Floor) VALUES ($t, $f)", ("$t", r.Title), ("$f", r.Floor));

        foreach (var d in devices)
            Exec(conn, tx, "INSERT INTO Devices (RoomId, Model, Power, Type) VALUES ($r, $m, $p, $t)",
                ("$r", d.RoomId), ("$m", d.Model), ("$p", d.Power), ("$t", d.Type));

        var rnd = new Random(42);
        for (int deviceId = 1; deviceId <= devices.Length; deviceId++)
        {
            var d = devices[deviceId - 1];
            double baseValue = d.Type == "Sensor" ? 20 : d.Power * 0.8;
            for (int i = 0; i < 5; i++)
            {
                double reading = Math.Round(baseValue + rnd.NextDouble() * 5, 2);
                string timestamp = DateTime.Today.AddHours(-i).ToString("yyyy-MM-dd HH:mm:ss");
                Exec(conn, tx, "INSERT INTO TelemetryLogs (DeviceId, Reading, Timestamp) VALUES ($d, $r, $ts)",
                    ("$d", deviceId), ("$r", reading), ("$ts", timestamp));
            }
        }

        tx.Commit();
    }

    private static void Exec(SqliteConnection conn, SqliteTransaction? tx, string sql,
        params (string Name, object Value)[] args)
    {
        using var cmd = conn.CreateCommand();
        cmd.Transaction = tx;
        cmd.CommandText = sql;
        foreach (var (name, value) in args)
            cmd.Parameters.AddWithValue(name, value);
        cmd.ExecuteNonQuery();
    }
}
