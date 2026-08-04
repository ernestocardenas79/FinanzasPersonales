using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Core.DTOs;
using PersonalFinance.Core.Models;

namespace PersonalFinance.Data.Repositories;

public class AccountRepository(FinanceDbContext context): GenericRepository<Account>(context),IAccountRepository
{
    private DbSet<Account> Account { get; init; } = context.Set<Account>();

    public async Task<Account> GetAccountAsync(string name)
    {
        var account = await Account
                                .AsNoTracking()
                                .Where(b=> b.Name.Equals(name))
                                .FirstAsync();
        return account;
    }
}