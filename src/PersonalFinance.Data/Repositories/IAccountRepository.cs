using PersonalFinance.Core.DTOs;
using PersonalFinance.Core.Models;

namespace PersonalFinance.Data.Repositories;

public interface IAccountRepository
{
    Task<Account> GetAccountAsync(string name);
}