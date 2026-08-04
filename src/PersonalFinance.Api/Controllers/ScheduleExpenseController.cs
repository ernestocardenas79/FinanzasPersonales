using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Core.DTOs;
using PersonalFinance.Core.Enums;
using PersonalFinance.Core.Models;
using PersonalFinance.Data.Repositories;

namespace PersonalFinance.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ScheduledExpenseController(IGenericRepository<ScheduledMovement> repository): ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ScheduledExpenseDto>>> GetAll()
    {
        var movements = await repository.GetAllAsync();
        return Ok(movements);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<ScheduledExpenseDto>>> Get(int id)
    {
        var movement = await repository.GetByIdAsync(id);
        return Ok(movement);
    }
    
    [HttpPost]
    public async Task<ActionResult<ScheduledExpenseDto>> Post(ScheduledExpenseDto  scheduledExpense)
    {
        Enum.TryParse<Frequency>(scheduledExpense.Frequency, out var frequency);
        
        ScheduledMovement newMovement = new()
        {
            Frequency = frequency,
            Amount = scheduledExpense.Amount,
            NumberOfPeriods = scheduledExpense.NumberOfPeriods,
            Concept =  scheduledExpense.Concept
        };
        
        await repository.AddAsync(newMovement);
        await repository.SaveAsync();
        return Created("api/ScheduledExpense",newMovement);
    }
    
    [HttpPut]
    public async Task<ActionResult<ScheduledExpenseDto>> Update(ScheduledExpenseDto  scheduledExpense, int id)
    {
        var movement = await repository.GetByIdAsync(id);
        
        if (movement == null) return NotFound();

        Enum.TryParse<Frequency>(scheduledExpense.Frequency,out var frequency);
        movement.Frequency = frequency;
        movement.Amount = scheduledExpense.Amount;
        movement.NumberOfPeriods = scheduledExpense.NumberOfPeriods;
        movement.Concept = scheduledExpense.Concept;
        
        repository.Update(movement);
        await repository.SaveAsync();
        
        return NoContent();
    }
    
    [HttpDelete]
    public async Task<ActionResult<ScheduledExpenseDto>> Delete(int id)
    {
        var movement = await repository.GetByIdAsync(id);
        
        if (movement == null) return NotFound();
        
        repository.Delete(movement);
        await repository.SaveAsync();
        
        return NoContent();
    }
}