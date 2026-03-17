using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Core.DTOs;
using PersonalFinance.Data.Repositories;

namespace PersonalFinance.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BudgetController(IBudgetRepository budgetRepository) : ControllerBase
{
    private readonly IBudgetRepository _budgetRepository = budgetRepository;

    [HttpGet]
    public async Task<ActionResult<ResponseBudgetDto>> Get()
    {
        var budgets = await _budgetRepository.GetAllAsync();
        return Ok(budgets);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ResponseBudgetDto>> Get(int id)
    {
        var budget = await _budgetRepository.GetAsync(id);
        return Ok(budget);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseBudgetDto>> Create(BudgetDto budgetDto)
    {
        var createdBudget = await _budgetRepository.AddAsync(budgetDto);
        return Created("api/Budget", createdBudget);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<ResponseBudgetDto>> Put(BudgetDto budgetDto, int id)
    {
        await _budgetRepository.UpdateAsync(budgetDto, id);
        return NoContent();
    }
}