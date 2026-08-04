namespace PersonalFinance.Core.DTOs;

public class CreateDebitAccountDto
{
    public required string Name { get; set; }
    public Decimal OpeningBalance { get; set; }
}