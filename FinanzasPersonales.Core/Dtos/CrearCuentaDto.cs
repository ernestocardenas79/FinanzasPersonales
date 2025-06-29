using FinanzasPersonales.Core.Modelos;

public abstract class CuentaDto
{
    public required string Nombre { get; set; }
    public TipoCuenta TipoCuenta { get; set; } = TipoCuenta.CuentaDebito;
    public short DiaCorte { get; set; } = 5;

}


public class CrearCuentaDebitoDto : CuentaDto
{
    public Decimal SaldoInicial { get; set; }
}
