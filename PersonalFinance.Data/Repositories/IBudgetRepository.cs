using PersonalFinance.Core.DTOs;
using PersonalFinance.Core.Models;

namespace PersonalFinance.Data.Repositories;

public interface IBudgetRepository
{
    Task<ResponseBudgetDto> GetAsync(int id);
    Task<IEnumerable<ResponseBudgetDto>> GetAllAsync();
    Task<ResponseBudgetDto> AddAsync(BudgetDto budgetDto);
    Task<ResponseBudgetDto> UpdateAsync(BudgetDto budgetDto, int id);
}