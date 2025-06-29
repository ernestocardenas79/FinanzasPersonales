namespace FinanzasPersonales.Core.Modelos;

public class TipoCuenta
{
    public static readonly TipoCuenta CuentaDebito = new TipoCuenta
    {
        Id = 1,
        Nombre = "Cuenta Débito",
        EsIngreso = true
    };

    public static readonly TipoCuenta CuentaCredito = new TipoCuenta
    {
        Id = 2,
        Nombre = "Cuenta Crédito",
        EsIngreso = false
    };
    public static readonly TipoCuenta Efectivo = new TipoCuenta
    {
        Id = 3,
        Nombre = "Efectivo",
        EsIngreso = true
    };

    public static readonly TipoCuenta Inversion = new TipoCuenta
    {
        Id = 4,
        Nombre = "Inversión",
        EsIngreso = true
    };

    public int Id { get; set; }
    public required string Nombre { get; set; }
    public bool EsIngreso { get; set; }
}
