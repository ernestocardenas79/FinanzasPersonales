namespace PersonalFianance.Core.Models;

public class Transaction : Movement
{
    public DateTime Date { get; set; }
    public int Type { get; set; }
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;
}
