using Mbsample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbsample.Application.Contracts;

public interface ICustomerRepository
{
    public Task<int?> CreateCustomerAsync(Customer customer);
}
