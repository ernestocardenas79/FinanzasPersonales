using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalFianance.Core.Models;
using PersonalFianance.Data;
using PersonalFianance.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace PersonalFianance.Tests;

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
            Nombre = "Test",
            Saldo = 100,
            TipoId = 1,
            Tipo = new AccountType { Id = 5, Name = "Mega  Gasto", IsIncome = true }
        };

        // Act
        await repository.AddAsync(entity);
        await repository.SaveAsync();

        // Assert
        var result = await repository.GetByIdAsync(1);
        Assert.NotNull(result);
        Assert.Equal("Test", result.Nombre);
    }
}