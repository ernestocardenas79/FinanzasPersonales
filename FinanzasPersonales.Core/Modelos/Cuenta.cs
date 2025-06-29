using System.Collections.Generic;
namespace FinanzasPersonales.Core.Modelos;

public class Cuenta
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public decimal Saldo { get; set; }
    public required TipoCuenta Tipo { get; set; }
    public required int TipoId { get; set; }
    public required short DiaCorte { get; set; }
    public virtual ICollection<Transaccion>? Transacciones { get; set; }
}
