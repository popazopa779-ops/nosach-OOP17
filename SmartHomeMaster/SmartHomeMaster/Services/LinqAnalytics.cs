using SmartHomeMaster.Models;

namespace SmartHomeMaster.Services;

public static class LinqAnalytics
{
    public static List<DeviceReportDto> BuildReport(List<Room> rooms, List<Device> devices)
    {
        return devices
            .Join(rooms,
                d => d.RoomId,
                r => r.Id,
                (d, r) => new DeviceReportDto(d.Id, d.Model, d.GetType().Name, d.Power, r.Title, r.Floor))
            .ToList();
    }

    public static List<string> GroupJoinSummary(List<Room> rooms, List<Device> devices, List<TelemetryLog> logs)
    {
        var result = new List<string> { "GroupJoin: комнаты -> устройства" };

        result.AddRange(rooms.GroupJoin(devices,
            r => r.Id,
            d => d.RoomId,
            (r, ds) => $"  {r.Title} (этаж {r.Floor}): устройств - {ds.Count()}"));

        result.Add("GroupJoin: устройства -> журнал показаний");
        result.AddRange(devices.GroupJoin(logs,
            d => d.Id,
            l => l.DeviceId,
            (d, ls) =>
            {
                var list = ls.ToList();
                double avg = list.Count == 0 ? 0 : list.Average(l => l.Reading);
                return $"  {d.Model} #{d.Id}: показаний {list.Count}, среднее {avg:0.##}";
            }));

        return result;
    }

    public static List<DeviceReportDto> FilterSort(List<DeviceReportDto> report, double minPower)
    {
        return report
            .Where(d => d.Power >= minPower)
            .OrderBy(d => d.Floor)
            .ThenByDescending(d => d.Power)
            .ToList();
    }

    public static List<T> GetPage<T>(IEnumerable<T> source, int page, int pageSize)
    {
        return source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

    public static List<string> GroupStats(List<DeviceReportDto> report)
    {
        return report
            .GroupBy(d => d.RoomTitle)
            .Select(g =>
            {
                string models = g.Aggregate(string.Empty,
                    (acc, d) => acc.Length == 0 ? d.Model : acc + ", " + d.Model);
                return $"{g.Key}: Count={g.Count()}, Sum={g.Sum(d => d.Power):0.##} Вт, " +
                       $"Average={g.Average(d => d.Power):0.##} Вт; модели: {models}";
            })
            .ToList();
    }

    public static List<string> CompareRooms(List<DeviceReportDto> report, string roomA, string roomB)
    {
        List<string> a = report.Where(d => d.RoomTitle == roomA).Select(d => d.Model).ToList();
        List<string> b = report.Where(d => d.RoomTitle == roomB).Select(d => d.Model).ToList();

        return new List<string>
        {
            $"Intersect (общие модели): {Show(a.Intersect(b))}",
            $"Except ({roomA} без {roomB}): {Show(a.Except(b))}",
            $"Except ({roomB} без {roomA}): {Show(b.Except(a))}",
            $"Union (все модели): {Show(a.Union(b))}"
        };
    }

    private static string Show(IEnumerable<string> items)
    {
        List<string> list = items.ToList();
        return list.Count == 0 ? "-" : string.Join(", ", list);
    }

    public static List<string> QuantifierChecks(List<DeviceReportDto> report, double powerLimit)
    {
        bool any = report.Any(d => d.Power > powerLimit);
        bool all = report.All(d => d.Power > 0);
        DeviceReportDto? first = report.FirstOrDefault(d => d.Power > powerLimit);
        DeviceReportDto? missing = report.FirstOrDefault(d => d.Model == "NoSuchModel");

        return new List<string>
        {
            $"Any(Power > {powerLimit:0.##}): {any}",
            $"All(Power > 0): {all}",
            first is null
                ? $"FirstOrDefault(Power > {powerLimit:0.##}): null (подходящих устройств нет)"
                : $"FirstOrDefault(Power > {powerLimit:0.##}): {first.Model} ({first.Power:0.##} Вт, {first.RoomTitle})",
            missing is null
                ? "FirstOrDefault(Model == \"NoSuchModel\"): null - обращение к свойствам без проверки привело бы к ошибке"
                : "FirstOrDefault(Model == \"NoSuchModel\"): найден"
        };
    }

    public static List<string> DeferredVsMaterialized(List<DeviceReportDto> report, double minPower)
    {
        var source = new List<DeviceReportDto>(report);

        IEnumerable<DeviceReportDto> deferred = source.Where(d => d.Power >= minPower);   // запрос ещё не выполнен
        List<DeviceReportDto> materialized = source.Where(d => d.Power >= minPower).ToList(); // выполнен сразу

        int deferredBefore = deferred.Count();
        int materializedBefore = materialized.Count;

        source.Add(new DeviceReportDto(-1, "Новое устройство", "SmartActuator", minPower + 1000, "Тест", 0));

        return new List<string>
        {
            $"До добавления: отложенный запрос = {deferredBefore}, ToList() = {materializedBefore}",
            "В исходный список добавлено новое устройство с большой мощностью.",
            $"После добавления: отложенный запрос = {deferred.Count()} (перевычислен при обращении), ToList() = {materialized.Count} (снимок не изменился)"
        };
    }
}
