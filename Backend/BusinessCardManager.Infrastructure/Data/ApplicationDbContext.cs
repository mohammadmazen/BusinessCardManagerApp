using BusinessCardManager.Domain.Entities;
using BusinessCardManager.Domain.Interfaces.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BusinessCardManager.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<BusinessCard> BusinessCards { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BusinessCardConfiguration());
    }
}