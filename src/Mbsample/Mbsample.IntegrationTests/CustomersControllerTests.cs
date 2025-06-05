using FluentAssertions;
using Mbsample.Application.DTOs;
using Mbsample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Json;

namespace Mbsample.IntegrationTests
{
    public class CustomersControllerTests : IClassFixture<MbsampleApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly MbsampleApplicationFactory _factory;
        private IServiceScope _scope;
        private CustomerDbContext _dbContext;

        public CustomersControllerTests(MbsampleApplicationFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
            _scope = factory.Services.CreateScope(); // Create a scope
            _dbContext = _scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
        }

        [Fact]
        public async Task Given_valid_createcustomerdto_Then_return_created_status_code()
        {
            //Arrange
            var dto = new CreateCustomerDto(
                FirstName: "John",
                LastName: "Smith",
                Email: "test@example.com",
                Phone: "1234567890");

            //Act
            var response = await _client.PostAsJsonAsync("/api/v1/customers", dto);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Verify database
            var customer = await _dbContext.Customers.FirstOrDefaultAsync();
            customer.Should().NotBeNull();
            customer!.FirstName.Should().Be(dto.FirstName);
            customer!.LastName.Should().Be(dto.LastName);
            customer!.Email.Should().Be(dto.Email);
            customer!.Phone.Should().Be(dto.Phone);
        }
    }
}