using Microsoft.EntityFrameworkCore;
using PersonalFinance.Core.Models;
using PersonalFinance.Data;
using PersonalFinance.Data.Repositories;

namespace PersonalFinance.Tests;

public class GenericRepositoryTests
{
    private DbContextOptions<FinanceDbContext> GetInMemoryOptions()
    {
        return new DbContextOptionsBuilder<FinanceDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        // Arrange
        var options = GetInMemoryOptions();
        using var context = new FinanceDbContext(options);
        var repository = new GenericRepository<Account>(context);
        var entity = new Account
        {
            Id = 1,
            Name = "Test",
            Balance = 100,
            TypeId = 1,
            Type = new AccountType { Id = 5, Name = "Mega  Gasto", IsIncome = true },
            BillingCycleDate = 15
		};

        // Act
        await repository.AddAsync(entity);
        await repository.SaveAsync();

        // Assert
        var result = await repository.GetByIdAsync(1);
        Assert.NotNull(result);
        Assert.Equal("Test", result.Name);
    }
}