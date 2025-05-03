using FinanzasPersonales.Core.Enums;
using FinanzasPersonales.Core.Modelos;

namespace FinanzasPersonales.Api.Modelos;
public class GastoProgramado : Movimiento
{
    public Periodicidad Periodicidad { get; set; } = Periodicidad.Mensual;
    public int CantidadPeriodos { get; set; } = 1;
}
