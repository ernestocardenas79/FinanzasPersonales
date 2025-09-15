using PersonalFinance.Data;
using PersonalFinance.Core.Models;
using PersonalFinance.Data.Repositories;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(FinanceDbContext context) : base(context)
    { }
}
