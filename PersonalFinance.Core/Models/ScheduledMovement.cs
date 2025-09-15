using PersonalFinance.Core.Enums;
using PersonalFinance.Core.Models;

namespace PersonalFinance.Core.Models;

public class ScheduledMovement : Movement
{
    public Frequency Frequency { get; set; } = Frequency.Monthly;
    public int NumberOfPeriods { get; set; } = 1;
    public Account? TargetAccount { get; set; }
}
