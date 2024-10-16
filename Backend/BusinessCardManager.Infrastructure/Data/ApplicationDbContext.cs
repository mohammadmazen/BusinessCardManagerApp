using BusinessCardManager.Domain.Entities;
using BusinessCardManager.Domain.Interfaces.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Apply other configurations
    }
}