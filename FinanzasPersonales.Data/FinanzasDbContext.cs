using Microsoft.EntityFrameworkCore;
using FinanzasPersonales.Core.Modelos;
using FinanzasPersonales.Api.Modelos;

namespace FinanzasPersonales.Data;

public class FinanzasDbContext : DbContext
{
    public FinanzasDbContext(DbContextOptions<FinanzasDbContext> options) : base(options) { }

    // DbSets para las entidades
    public DbSet<Cuenta> Cuentas { get; set; }
    public DbSet<Tipo> Tipos { get; set; }
    public DbSet<GastoProgramado> GastosProgramados { get; set; }
    public DbSet<Transaccion> Transacciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración adicional para las entidades
        modelBuilder
            .Entity<Cuenta>(m =>
            {
                m.HasOne(c => c.Tipo)
                 .WithOne()
                 .HasForeignKey<Cuenta>(c => c.TipoId);
                m.HasKey(c => c.Id);
            });

        modelBuilder.Entity<Transaccion>(m =>
        {
            m.HasOne(t => t.Cuenta)
             .WithMany(c => c.Transacciones)
             .HasForeignKey(t => t.CuentaId);
            m.HasKey(t => t.Id);
        });

        modelBuilder
        .Entity<Tipo>(m =>
        {
            m.HasKey(t => t.Id);
            m.HasData(new Tipo { Id = 1, Nombre = "Efectivo", EsIngreso = true },
            new Tipo { Id = 2, Nombre = "Cuenta Debito", EsIngreso = true },
            new Tipo { Id = 3, Nombre = "Cuenta Creadito", EsIngreso = false },
            new Tipo { Id = 4, Nombre = "Inversion", EsIngreso = true });
        });


        modelBuilder.Entity<GastoProgramado>().HasKey(m => m.Id);


        // Si tienes herencia o configuraciones específicas, puedes agregarlas aquí
    }
}