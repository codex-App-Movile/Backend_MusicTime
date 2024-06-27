namespace Backend_MusicTime.Customer.Interfaces.REST.Resources;

public record UpdateCustomerResource(string FirstName, string LastName, string Street, string Number, string City, string PostalCode, string Country);