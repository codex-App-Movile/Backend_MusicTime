namespace Backend_MusicTime.Enterprise.Interfaces.REST.Resources;

public record CreateEnterpriseResource(string Name, string Email, string Street, string Number, string City, string PostalCode, string Country);