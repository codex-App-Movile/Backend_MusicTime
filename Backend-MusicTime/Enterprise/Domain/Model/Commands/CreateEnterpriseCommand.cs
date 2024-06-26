namespace Backend_MusicTime.Enterprise.Domain.Model.Commands;

public record CreateEnterpriseCommand(string Name, string Email, string Street, string Number, string City, string PostalCode, string Country);