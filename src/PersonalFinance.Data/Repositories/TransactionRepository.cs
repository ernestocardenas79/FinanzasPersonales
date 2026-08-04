using Microsoft.EntityFrameworkCore;
using PersonalFinance.Core.Models;

namespace PersonalFinance.Data.Repositories;

public class TransactionRepository(FinanceDbContext context): GenericRepository<TransactionMovement>(context),ITransactionRepository
{
    private DbSet<TransactionMovement> Transaction { get; init; } = context.Set<TransactionMovement>();

    public async Task CreateTransactionAsync(TransactionMovement movement)
    {
        await AddAsync(movement);
        await SaveAsync();
    }
}