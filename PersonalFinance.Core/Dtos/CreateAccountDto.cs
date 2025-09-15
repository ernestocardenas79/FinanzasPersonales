using PersonalFinance.Core.Models;

public abstract class AccountDto
{
    public required string Name { get; set; }
    public AccountType AccountType { get; set; } = AccountType.DebitAccount;
    public short BillingCycleClosingDate { get; set; } = 5;
}

public class CreateDebitAccountDto
{
    public required string Name { get; set; }
    public Decimal OpeningBalance { get; set; }
}
