using SmartHomeMaster.Models;

namespace SmartHomeMaster.Services;

public static class DeviceDelegates
{
    public static readonly Func<Device, double> PowerSelector = d => d.CalculatePowerConsumption();

    public static Func<double, bool> CreateThresholdChecker(double threshold)
    {
        double limit = threshold; // локальная переменная внешнего контекста
        return consumption => consumption > limit;
    }

    public static Predicate<Device> CreateCriticalPredicate(double threshold)
    {
        Func<double, bool> exceeds = CreateThresholdChecker(threshold);
        return d => exceeds(PowerSelector(d));
    }

    public static List<Device> FindCritical(IEnumerable<Device> devices, double threshold, Action<string> log)
    {
        Predicate<Device> isCritical = CreateCriticalPredicate(threshold);
        List<Device> critical = devices.ToList().FindAll(isCritical);
        critical.ForEach(d => log($"Критично: {d.Model} (Id {d.Id}) потребляет {PowerSelector(d):0.##} Вт > {threshold:0.##} Вт"));
        return critical;
    }
}
