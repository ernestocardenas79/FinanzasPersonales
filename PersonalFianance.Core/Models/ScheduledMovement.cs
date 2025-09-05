using System.Diagnostics.Contracts;
using PersonalFianance.Core.Enums;
using PersonalFianance.Core.Models;

namespace PersonalFianance.Api.Models;

public class ScheduledMovement : Movement
{
    public Frequency Frequency { get; set; } = Frequency.Monthly;
    public int NumberOfPeriods { get; set; } = 1;
    public Account? TargetAccount { get; set; }
}
