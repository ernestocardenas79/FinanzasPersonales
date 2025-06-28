using System.Diagnostics.Contracts;
using FinanzasPersonales.Core.Enums;
using FinanzasPersonales.Core.Modelos;

namespace FinanzasPersonales.Api.Modelos;

public class MovimientoProgramado : Movimiento
{
    public Periodicidad Periodicidad { get; set; } = Periodicidad.Mensual;
    public int CantidadPeriodos { get; set; } = 1;
    public Cuenta? AfectarA { get; set; }
}
