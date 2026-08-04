using PersonalFinance.Core.Models;

namespace PersonalFinance.Core.DTOs;

public class AccountDto
{
    public required string Name { get; set; }
    public AccountType AccountType { get; set; } = AccountType.DebitAccount;
    public short BillingCycleClosingDate { get; set; } = 5;
}