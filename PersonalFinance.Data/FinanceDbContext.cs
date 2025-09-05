using Microsoft.EntityFrameworkCore;
using PersonalFianance.Core.Models;
using PersonalFianance.Api.Models;

namespace PersonalFianance.Data;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }

    // DbSets para las entidades
    public DbSet<Account> Cuentas { get; set; }
    public DbSet<AccountType> Tipos { get; set; }
    public DbSet<ScheduledMovement> MovimientosProgramados { get; set; }
    public DbSet<Transaction> Transacciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración adicional para las entidades
        modelBuilder
            .Entity<Account>(m =>
            {
                m.HasOne(c => c.Tipo)
                 .WithOne()
                 .HasForeignKey<Account>(c => c.TipoId);
                m.HasKey(c => c.Id);
            });

        modelBuilder.Entity<Transaction>(m =>
        {
            m.HasOne(t => t.Account)
             .WithMany(c => c.Transacciones)
             .HasForeignKey(t => t.AccountId);
            m.HasKey(t => t.Id);
        });

        modelBuilder
        .Entity<AccountType>(m =>
        {
            m.HasKey(t => t.Id);
            m.HasData(new AccountType { Id = 1, Name = "Efectivo", IsIncome = true },
            new AccountType { Id = 2, Name = "Cuenta Debito", IsIncome = true },
            new AccountType { Id = 3, Name = "Cuenta Creadito", IsIncome = false },
            new AccountType { Id = 4, Name = "Inversion", IsIncome = true });
        });


        modelBuilder.Entity<ScheduledMovement>().HasKey(m => m.Id);


        // Si tienes herencia o configuraciones específicas, puedes agregarlas aquí
    }
}