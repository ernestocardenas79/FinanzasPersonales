namespace PersonalFianance.Core.Models;

public class AccountType
{
    public static readonly AccountType DebitAccount = new AccountType
    {
        Id = 1,
        Name = "Debit Account",
        IsIncome = true
    };

    public static readonly AccountType CuentaCredito = new AccountType
    {
        Id = 2,
        Name = "Cuenta Crédito",
        IsIncome = false
    };
    public static readonly AccountType Cash = new AccountType
    {
        Id = 3,
        Name = "Cash",
        IsIncome = true
    };

    public static readonly AccountType Inversion = new AccountType
    {
        Id = 4,
        Name = "Investment",
        IsIncome = true
    };

    public int Id { get; set; }
    public required string Name { get; set; }
    public bool IsIncome { get; set; }
}
