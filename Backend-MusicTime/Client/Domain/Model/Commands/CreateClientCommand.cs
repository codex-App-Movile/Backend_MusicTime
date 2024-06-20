namespace Backend_MusicTime.Client.Domain.Model.Commands;

public record CreateClientCommand(string FirstName, string LastName, string Email, string Street, string Number, string City, string PostalCode, string Country);