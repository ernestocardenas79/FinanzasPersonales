using System.Collections.Generic;
namespace PersonalFianance.Core.Models;

public class Account
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public decimal Saldo { get; set; }
    public required AccountType Tipo { get; set; }
    public required int TipoId { get; set; }
    public required short DiaCorte { get; set; }
    public virtual ICollection<Transaction>? Transacciones { get; set; }
}
