using Microsoft.EntityFrameworkCore;
using PersonalFinance.Core.Models;

namespace PersonalFinance.Data;

public class FinanceDbContext(DbContextOptions<FinanceDbContext> options) : DbContext(options)
{
    // DbSets for the entities 
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<ScheduledMovement> ScheduledMovements { get; set; }
    public DbSet<TransactionMovement> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Additional entities's configuration 
        modelBuilder
            .Entity<Account>(m =>
            {
                m.HasOne(c => c.Type)
                 .WithOne()
                 .HasForeignKey<Account>(c => c.TypeId);
                m.HasKey(c => c.Id);
            });

        modelBuilder.Entity<TransactionMovement>(m =>
        {
            m.HasOne(t => t.Account);
            m.HasKey(t => t.Id);
        });

        modelBuilder
        .Entity<AccountType>(m =>
        {
            m.HasKey(t => t.Id);
            m.HasData(new AccountType { Id = 1, Name = "Efectivo", IsIncome = true },
            new AccountType { Id = 2, Name = "Cuenta Debito", IsIncome = true },
            new AccountType { Id = 3, Name = "Cuenta Credito", IsIncome = false },
            new AccountType { Id = 4, Name = "Inversion", IsIncome = true });
        });

        modelBuilder.Entity<ScheduledMovement>().HasKey(m => m.Id);

    }
}