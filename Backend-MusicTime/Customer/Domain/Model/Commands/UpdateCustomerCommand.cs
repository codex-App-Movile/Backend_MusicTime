namespace Backend_MusicTime.Customer.Domain.Model.Commands;

public record UpdateCustomerCommand(int Id, string FirstName, string LastName, string Street, string Number, string City, string PostalCode, string Country);