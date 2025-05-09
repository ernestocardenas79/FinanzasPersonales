using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCuentas()
        {
            return Ok(new { Message = "Listado de cuentas" });
        }

        [HttpPost]
        public IActionResult CrearCuenta([FromBody] object nuevaCuenta)
        {
            return Ok(new { Message = "Cuenta creada exitosamente" });
        }
    }
}