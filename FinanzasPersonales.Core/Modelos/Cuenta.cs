using System.Collections.Generic;
namespace FinanzasPersonales.Core.Modelos;

public class Cuenta
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public decimal Saldo { get; set; }
    public Tipo Tipo { get; set; }
    public required int TipoId { get; set; }

    // Navigation properties
    public virtual ICollection<Transaccion>? Transacciones { get; set; }
}
