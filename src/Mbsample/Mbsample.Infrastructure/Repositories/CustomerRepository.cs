using Mbsample.Application.Contracts;
using Mbsample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mbsample.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _context;
    public CustomerRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public async Task<int?> CreateCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        return await _context.SaveChangesAsync();
    }
}
