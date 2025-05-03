namespace FinanzasPersonales.Core.Modelos;
public abstract class Movimiento
{
    public int Id { get; set; }
    public string Concepto { get; set; }
    public decimal Monto { get; set; }
}
