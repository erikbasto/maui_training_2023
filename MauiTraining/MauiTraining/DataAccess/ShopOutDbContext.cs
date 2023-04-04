using MauiTraining.Services;
using Microsoft.EntityFrameworkCore;

namespace MauiTraining.DataAccess;

/// <summary>
/// Sql lite context for some examples on HelpSupport page.
/// </summary>
public class ShopOutDbContext : DbContext
{
    public DbSet<SaleItem> Sales { get; set; }

    private readonly IDatabasePathService _databasePathService;

    public ShopOutDbContext(IDatabasePathService databasePathService)
    {
        _databasePathService = databasePathService;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = $"Filename={_databasePathService.Get("shopdatabase.db")}";
        optionsBuilder.UseSqlite(connectionString);
    }
}

public record SaleItem(int ClientId, int ProductId, int Quantity, decimal Precio)
{
    public int Id { get; set; }
}

