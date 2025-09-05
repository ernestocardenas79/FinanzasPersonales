using PersonalFianance.Data;
using PersonalFianance.Core.Models;
using PersonalFianance.Data.Repositories;
public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(FinanceDbContext context) : base(context)
    { }
}
