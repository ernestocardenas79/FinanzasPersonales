using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Core.DTOs;
using PersonalFinance.Core.Models;
using PersonalFinance.Data.Repositories;

namespace PersonalFinance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IGenericRepository<Account> repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await repository.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await repository.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost("debit")]
        public async Task<IActionResult> CreateDebitAccount([FromBody] CreateDebitAccountDto newAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = new Account
            {
                Name = newAccount.Name,
                TypeId = AccountType.DebitAccount.Id,
                Balance = newAccount.OpeningBalance,
                BillingCycleDate = 5
            };

            await repository.AddAsync(account);
            await repository.SaveAsync();
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, newAccount);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] Account newAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await repository.AddAsync(newAccount);
            return CreatedAtAction(nameof(GetAccount), new { id = newAccount.Id }, newAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] Account updatedAccount)
        {
            if (id != updatedAccount.Id)
            {
                return BadRequest();
            }

            var existentAccount = await repository.GetByIdAsync(id);
            if (existentAccount == null)
            {
                return NotFound();
            }

            repository.Update(updatedAccount);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletingAccount(int id)
        {
            var account = await repository.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            repository.Delete(account);
            return NoContent();
        }
    }
}