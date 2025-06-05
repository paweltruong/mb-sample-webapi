using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbsample.Application.DTOs;

/// <summary>
/// Added fluent validations for DTO and not entity model for easy migration to CQRS pattern in the future.
/// </summary>
public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
{
    public CreateCustomerDtoValidator()
    {
        RuleFor(customer => customer.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");
        RuleFor(customer => customer.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(255).WithMessage("Last name must not exceed 255 characters.");
        RuleFor(customer => customer.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(255).WithMessage("Email must not exceed 255 characters.");
        RuleFor(customer => customer.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(64).WithMessage("Phone number must not exceed 64 characters.");
    }
}
