namespace Backend_MusicTime.Customer.Domain.Model.Commands;

public record CreateCustomerCommand(string FirstName, string LastName, string Email, string Street, string Number, string City, string PostalCode, string Country);