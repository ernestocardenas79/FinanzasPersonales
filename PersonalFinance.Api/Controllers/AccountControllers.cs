using Microsoft.AspNetCore.Mvc;
using PersonalFianance.Data.Repositories;
using PersonalFianance.Core.Models;

namespace PersonalFianance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IGenericRepository<Account> _repository;

        public AccountController(IGenericRepository<Account> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _repository.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _repository.GetByIdAsync(id);
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
                Type = AccountType.DebitAccount,
                TypeId = AccountType.DebitAccount.Id,
                Balance = newAccount.OpeningBalance,
                BillingCycleDate = 5
            };

            await _repository.AddAsync(account);
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, newAccount);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] Account newAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddAsync(newAccount);
            return CreatedAtAction(nameof(GetAccount), new { id = newAccount.Id }, newAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] Account updatedAccount)
        {
            if (id != updatedAccount.Id)
            {
                return BadRequest();
            }

            var existentAccount = await _repository.GetByIdAsync(id);
            if (existentAccount == null)
            {
                return NotFound();
            }

            _repository.Update(updatedAccount);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarCuenta(int id)
        {
            var cuenta = await _repository.GetByIdAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            _repository.Delete(cuenta);
            return NoContent();
        }
    }
}