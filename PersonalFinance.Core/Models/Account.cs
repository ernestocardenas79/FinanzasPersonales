using System.Collections.Generic;
namespace PersonalFianance.Core.Models;

public class Account
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Balance { get; set; }
    public required AccountType Type { get; set; }
    public required int TypeId { get; set; }
    public required short BillingCycleDate { get; set; }
    public virtual ICollection<Transaction>? Transactions { get; set; }
}
