namespace PersonalFinance.Core.Models;

public sealed class TransactionMovement : Movement
{
    public DateTime Date { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}
