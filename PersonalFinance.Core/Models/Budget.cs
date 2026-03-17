using PersonalFinance.Core.Enums;

namespace PersonalFinance.Core.Models;

public class Budget: ScheduledMovement
{
    public Budget()
    {
        Frequency = Frequency.Monthly;
    }

    public static Budget Create(decimal amount)
    {
        if (amount <= 0)
        {
            throw new Exception("Budget amount must be greater than zero"); 
        }
        return new Budget { Amount = amount };
    }
}