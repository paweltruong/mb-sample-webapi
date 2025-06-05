using FluentValidation.AspNetCore;
using FluentValidation;
using Mbsample.Infrastructure;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Mbsample.Application.DTOs;
using Mbsample.Application.Contracts;
using Mbsample.Infrastructure.Repositories;

//TODO:PTRU20250604 clean up this file with extensions

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Validations for DTOs
builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerDto>();
builder.Services.AddFluentValidationAutoValidation();


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

//Database
builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? throw new ArgumentException("Default connection string in config not found"));
    var inMemoryDbName = builder.Configuration.GetConnectionString("InMemoryDb") ?? throw new ArgumentException("InMemoryDb connection string in config not found");
    options.UseInMemoryDatabase(inMemoryDbName);//For testing only
});

//Versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);

    options.ApiVersionReader = ApiVersionReader.Combine(
      new QueryStringApiVersionReader("api-version"),
      new HeaderApiVersionReader("X-Version"),
      new UrlSegmentApiVersionReader());
});
builder.Services.AddVersionedApiExplorer(options =>
 {
     options.GroupNameFormat = "'v'VVV";
     options.SubstituteApiVersionInUrl = true;
 });

//Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }