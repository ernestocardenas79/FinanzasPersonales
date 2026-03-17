using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Core.DTOs;
using PersonalFinance.Core.Models;

namespace PersonalFinance.Data.Repositories;

public class BudgetRepository(FinanceDbContext context) : IBudgetRepository
{
    private DbSet<ScheduledMovement> Budget { get; init; } = context.Set<ScheduledMovement>();

    public async Task<ResponseBudgetDto> GetAsync(int id)
    {
        var budget = await Budget.Where(b=> b.Id==id).FirstOrDefaultAsync();
        if (budget == null)
            return new(){Name = ""};
            
        var result = new ResponseBudgetDto()
        {
            Amount = budget.Amount,
            Name = budget.Concept,
            Id = budget.Id
        };

        return result;
    }

    public async Task<IEnumerable<ResponseBudgetDto>> GetAllAsync()
    {
        var sm = await Budget.ToListAsync();
        var result = from budget in sm select new ResponseBudgetDto()
        {
            Amount = budget.Amount,
            Name = budget.Concept,
            Id=budget.Id
        };
        return result;
    }

    public async Task<ResponseBudgetDto> AddAsync(BudgetDto budgetDto)
    {
        Budget budget = new()
        {
            Concept = budgetDto.Name,
            Amount = budgetDto.Amount
        };
        
        var newBudget = await Budget.AddAsync(budget);
        await context.SaveChangesAsync();
        return new()
        {
            Amount = newBudget.Entity.Amount,
            Name = newBudget.Entity.Concept,
            Id = newBudget.Entity.Id
        };
    }

    public async Task<ResponseBudgetDto> UpdateAsync(BudgetDto budgetDto, int id)
    {
        var scheduledMovement = await Budget.Where(b=> b.Id==id).FirstOrDefaultAsync();
        if (scheduledMovement == null)
            return new(){Name = ""};
        
        scheduledMovement.Amount = budgetDto.Amount;
        scheduledMovement.Concept = budgetDto.Name;
        context.Update(scheduledMovement);
        await context.SaveChangesAsync();

        return new ResponseBudgetDto()
        {
            Amount = budgetDto.Amount,
            Name = scheduledMovement.Concept,
            Id = scheduledMovement.Id
        };
    }
}