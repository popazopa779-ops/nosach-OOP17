namespace OperatorsLab;

public class AccountBalance
{
    private static int _idCounter;

    public int Id { get; }

    public decimal TotalBalance { get; set; }

    public AccountBalance(decimal initialBalance)
    {
        Id = ++_idCounter;
        TotalBalance = initialBalance;
    }

    public virtual void operator +=(decimal amount)
    {
        TotalBalance += amount;
    }

    public void operator +=(AccountBalance other)
    {
        TotalBalance += other.TotalBalance;
    }

    public void operator ++()
    {
        TotalBalance += 1m;
    }

    public static AccountBalance operator ++(AccountBalance a)
    {
        return new AccountBalance(a.TotalBalance + 1m);
    }

    public override string ToString() => $"Счёт #{Id}: {TotalBalance:0.00} руб.";
}
