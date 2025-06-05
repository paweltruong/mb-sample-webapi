using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mbsample.Domain.Entities;

namespace Mbsample.Infrastructure;

internal sealed class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        //Setup the table name and columns for db optimizations and consistency
        builder.ToTable("Customers");
        builder.HasKey(customer => customer.Id);
        builder.Property(customer => customer.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(customer => customer.LastName).IsRequired().HasMaxLength(255);
        builder.Property(customer => customer.Email).IsRequired().HasMaxLength(255);
        builder.Property(customer => customer.Phone).IsRequired().HasMaxLength(64);
        builder.Property(customer => customer.DateCreated).IsRequired();
    }
}