using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasPersonales.Core.Modelos;
using FinanzasPersonales.Data;
using FinanzasPersonales.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FinanzasPersonales.Tests;

public class GenericRepositoryTests
{
    private DbContextOptions<FinanzasDbContext> GetInMemoryOptions()
    {
        return new DbContextOptionsBuilder<FinanzasDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        // Arrange
        var options = GetInMemoryOptions();
        using var context = new FinanzasDbContext(options);
        var repository = new GenericRepository<Cuenta>(context);
        var entity = new Cuenta
        {
            Id = 1,
            Nombre = "Test",
            Saldo = 100,
            TipoId = 1,
            Tipo = new TipoCuenta { Id = 5, Nombre = "Mega  Gasto", EsIngreso = true }
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