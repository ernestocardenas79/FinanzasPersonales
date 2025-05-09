using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Data.Repositories;
using FinanzasPersonales.Core.Modelos;

namespace FinanzasPersonales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly IGenericRepository<Cuenta> _repository;

        public CuentasController(IGenericRepository<Cuenta> repository)
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

        [HttpPost]
        public async Task<IActionResult> CrearCuenta([FromBody] Cuenta nuevaCuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddAsync(nuevaCuenta);
            return CreatedAtAction(nameof(GetCuenta), new { id = nuevaCuenta.Id }, nuevaCuenta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCuenta(int id, [FromBody] Cuenta cuentaActualizada)
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