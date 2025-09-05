using Microsoft.AspNetCore.Mvc;
using PersonalFianance.
using PersonalFianance.Core.Models;

namespace PersonalFianance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly IGenericRepository<Account> _repository;

        public CuentasController(IGenericRepository<Account> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCuentas()
        {
            var cuentas = await _repository.GetAllAsync();
            return Ok(cuentas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCuenta(int id)
        {
            var cuenta = await _repository.GetByIdAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }
            return Ok(cuenta);
        }

        // [HttpPost("debito")]
        // public async Task<IActionResult> CrearCuentaDebito([FromBody] CreateDebitAccountDto nuevaCuenta)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     await _repository.AddAsync(nuevaCuenta);
        //     return CreatedAtAction(nameof(GetCuenta), new { id = nuevaCuenta.Id }, nuevaCuenta);
        // }


        [HttpPost]
        public async Task<IActionResult> CrearCuenta([FromBody] Account nuevaCuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddAsync(nuevaCuenta);
            return CreatedAtAction(nameof(GetCuenta), new { id = nuevaCuenta.Id }, nuevaCuenta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCuenta(int id, [FromBody] Account cuentaActualizada)
        {
            if (id != cuentaActualizada.Id)
            {
                return BadRequest();
            }

            var cuentaExistente = await _repository.GetByIdAsync(id);
            if (cuentaExistente == null)
            {
                return NotFound();
            }

            _repository.Update(cuentaActualizada);
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