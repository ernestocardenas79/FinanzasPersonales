namespace PersonalFinance.Core.Models;

public class TransactionMovement : Movement
{
    public DateTime Date { get; set; }
    public int Type { get; set; }
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;
}
