using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbsample.Application.DTOs;

//Can be later converted into Command for CQRS pattern
public record class CreateCustomerDto(
    string FirstName,
    string LastName,
    string Email,
    string Phone);
