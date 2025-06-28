using System.Runtime.CompilerServices;

namespace FinanzasPersonales.Core.Modelos;

public abstract class Movimiento
{
    public int Id { get; set; }
    public string Concepto { get; set; } = string.Empty;
    public decimal Monto { get; set; }
}
