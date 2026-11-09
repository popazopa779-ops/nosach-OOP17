namespace OperatorsLab;

public class CurrencyRecord
{
    public string Code { get; set; } = "RUB";
    public decimal Amount { get; set; }

    public override string ToString() => $"{Amount:0.00} {Code}";
}
