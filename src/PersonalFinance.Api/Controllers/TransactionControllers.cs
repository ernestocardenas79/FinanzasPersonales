using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Core.DTOs;
using PersonalFinance.Core.Models;
using PersonalFinance.Data.Repositories;

namespace PersonalFinance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController(IGenericRepository<TransactionMovement> repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTransaction()
        {
            var accounts = await repository.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await repository.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] TransactionMovement newTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = new TransactionMovement
            {
                AccountId = newTransaction.AccountId,
                Date =  newTransaction.Date,
                Amount = newTransaction.Amount,
                Concept =  newTransaction.Concept,
            };

            await repository.AddAsync(transaction);
            await repository.SaveAsync();
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, newTransaction);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TransactionMovement updatedTransaction)
        {
            if (id != updatedTransaction.Id)
            {
                return BadRequest();
            }

            var existentTransaction = await repository.GetByIdAsync(id);
            if (existentTransaction == null)
            {
                return NotFound();
            }

            repository.Update(updatedTransaction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleting(int id)
        {
            var transaction = await repository.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            repository.Delete(transaction);
            return NoContent();
        }
    }
}