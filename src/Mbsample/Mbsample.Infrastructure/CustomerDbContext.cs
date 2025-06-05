using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mbsample.Domain.Entities;

namespace Mbsample.Infrastructure;

public sealed class CustomerDbContext : DbContext
{
    private const string Schema = "mbsample";

    public DbSet<Customer> Customers => Set<Customer>();

    public CustomerDbContext(DbContextOptions options)
        : base(options)
    {
        // Ensure the database is created  
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
    }
}
