using Mbsample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbsample.Application.DTOs;

public static class CustomerMappings
{
    public static Customer ToEntity(this CreateCustomerDto dto)
    {
        return new Customer
        {
            Id = Guid.NewGuid(), // Assuming a new ID is generated for each new customer
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
        };
    }
}