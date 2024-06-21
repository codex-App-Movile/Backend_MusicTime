namespace Backend_MusicTime.Customer.Interfaces.REST.Resources;

public record CreateCustomerResource(string FirstName, string LastName, string Email, string Street, string Number, string City, string PostalCode, string Country);