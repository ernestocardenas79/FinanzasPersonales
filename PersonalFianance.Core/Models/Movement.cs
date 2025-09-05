namespace PersonalFianance.Core.Models;

public abstract class Movement
{
    public int Id { get; set; }
    public string Concept { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
