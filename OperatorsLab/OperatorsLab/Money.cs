namespace OperatorsLab;

public class Money : IEquatable<Money>
{
    public int Rubles { get; }
    public int Kopeks { get; }

    public Money(int rubles, int kopeks) : this((long)rubles * 100 + kopeks)
    {
    }

    public Money(long totalKopeks)
    {
        long r = totalKopeks / 100;
        long k = totalKopeks % 100;
        if (k < 0)
        {
            k += 100;
            r--;
        }
        Rubles = checked((int)r);
        Kopeks = (int)k;
    }

    public long TotalKopeks => (long)Rubles * 100 + Kopeks;

    public static Money operator +(Money a, Money b) => new Money(a.Rubles + b.Rubles, a.Kopeks + b.Kopeks);

    public static Money operator -(Money a, Money b) => new Money(a.Rubles - b.Rubles, a.Kopeks - b.Kopeks);

    public static Money operator +(Money a, int rubles) => new Money(a.Rubles + rubles, a.Kopeks);

    public static bool operator <(Money a, Money b) => a.TotalKopeks < b.TotalKopeks;

    public static bool operator >(Money a, Money b) => a.TotalKopeks > b.TotalKopeks;

    public static bool operator ==(Money? a, Money? b)
    {
        if (a is null || b is null) return a is null && b is null;
        return a.TotalKopeks == b.TotalKopeks;
    }

    public static bool operator !=(Money? a, Money? b) => !(a == b);

    public static bool operator true(Money m) => m.TotalKopeks > 0;

    public static bool operator false(Money m) => m.TotalKopeks <= 0;

    public static bool operator !(Money m) => m.TotalKopeks <= 0;

    public static explicit operator long(Money m) => m.TotalKopeks;

    public static implicit operator Money(long totalKopeks) => new Money(totalKopeks);
    public static explicit operator CurrencyRecord(Money m) =>
        new CurrencyRecord { Code = "RUB", Amount = m.Rubles + m.Kopeks / 100m };

    public static explicit operator Money(CurrencyRecord cr)
    {
        long total = (long)Math.Round(cr.Amount * 100m, MidpointRounding.AwayFromZero);
        return new Money(total);
    }

    public bool Equals(Money? other) => other is not null && TotalKopeks == other.TotalKopeks;

    public override bool Equals(object? obj) => obj is Money m && Equals(m);

    public override int GetHashCode() => TotalKopeks.GetHashCode();

    public override string ToString() => $"{Rubles} руб. {Kopeks:D2} коп.";
}
