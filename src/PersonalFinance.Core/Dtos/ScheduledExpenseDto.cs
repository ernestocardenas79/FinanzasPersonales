using PersonalFinance.Core.Enums;

namespace PersonalFinance.Core.DTOs;

public class ScheduledExpenseDto
{
    public string Concept { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Frequency { get; set; } = "Monthly";
    public int NumberOfPeriods { get; set; } = 0;
    public string? TargetAccount { get; set; }
}