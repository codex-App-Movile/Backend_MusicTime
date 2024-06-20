namespace Backend_MusicTime.Client.Interfaces.REST.Resources;

public record CreateClientResource(string FirstName, string LastName, string Email, string Street, string Number, string City, string PostalCode, string Country);