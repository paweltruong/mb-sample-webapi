namespace Mbsample.Domain.Entities;

public sealed class Customer
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public DateTime? DateCreated { get; init; } = DateTime.UtcNow;
    public DateTime? DateModified { get; init; } = null;
}
