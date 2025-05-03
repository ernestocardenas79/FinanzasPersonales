namespace FinanzasPersonales.Core.Modelos;
public class Transaccion : Movimiento
{
    public DateTime Fecha { get; set; }
    public int TipoId { get; set; }
    public int CuentaId { get; set; }
    public virtual Cuenta Cuenta { get; set; } = null!;
}
