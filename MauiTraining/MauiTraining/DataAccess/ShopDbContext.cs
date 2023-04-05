using Microsoft.EntityFrameworkCore;

namespace MauiTraining.DataAccess;

/// <summary>
/// In memory context used for some examples.
/// </summary>
public class ShopDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ShopComputer");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category(1, "Electronics"),
            new Category(2, "Computers"),
            new Category(3, "Phones"),
            new Category(4, "PCs"),
            new Category(5, "Audio"),
            new Category(6, "HomeLine"),
            new Category(7, "Toys"));

        modelBuilder.Entity<Product>().HasData(
            new Product(1, "Radio", "Amazing radio", 100, 1),
            new Product(2, "Clock", "Digital clock", 50, 1),
            new Product(3, "Laptop hp", "laptop hp", 900, 2),
            new Product(4, "Laptop Acer", "Laptop accer", 800, 2),
            new Product(5, "Mac", "Macbook pro 2020", 2000, 2),
            new Product(6, "Samsung Galaxy", "Samsung Galaxy", 500, 3),
            new Product(7, "iPhone", "iPhone 14", 500, 2));

        modelBuilder.Entity<Client>().HasData(
            new Client(1, "Juan Gomez", "Avenida Gonzalez No 123"),
            new Client(2, "Bart Simpson", "Fake St 123"));
    }
}

public record Category(int Id, string Name);
public record Product(int Id, string Name, string Description, decimal Price, int CategoryId)
{
    public Category Category { get; set; }
}
public record Client(int Id, string Name, string Address);

public record Sale(
    int ClientId,
    int ProductId,
    int Quantity,
    string ProductName,
    decimal ProductPrice,
    decimal Total);

