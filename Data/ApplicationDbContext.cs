using Microsoft.EntityFrameworkCore;
using AsyncLab.Models;

namespace AsyncLab.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Coffee", Price = 4.99M },
            new Product { Id = 2, Name = "Tea", Price = 3.99M },
            new Product { Id = 3, Name = "Cookie", Price = 2.49M }
        );
    }
} 