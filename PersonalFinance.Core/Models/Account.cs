using System.Collections.Generic;
namespace PersonalFinance.Core.Models;

public class Account
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Balance { get; set; }
    public AccountType Type { get; set; }
    public int TypeId { get; set; }
    public required short BillingCycleDate { get; set; }
}
