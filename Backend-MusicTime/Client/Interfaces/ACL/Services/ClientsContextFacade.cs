using Backend_MusicTime.Client.Domain.Model.Commands;
using Backend_MusicTime.Client.Domain.Model.Queries;
using Backend_MusicTime.Client.Domain.Model.ValueObjects;
using Backend_MusicTime.Client.Domain.Services;

namespace Backend_MusicTime.Client.Interfaces.ACL.Services;

public class ClientsContextFacade(IClientCommandService clientCommandService, IClientQueryService clientQueryService) : IClientsContextFacade
{
    public async Task<int> CreateClient(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country)
    {
        var createClientCommand = new CreateClientCommand(firstName, lastName, email, street, number, city, postalCode, country);
        var client = await clientCommandService.Handle(createClientCommand);
        return client?.Id ?? 0;
    }

    public async Task<int> FetchClientIdByEmail(string email)
    {
        var getClientByEmailQuery = new GetClientByEmailQuery(new EmailAddress(email));
        var client = await clientQueryService.Handle(getClientByEmailQuery);
        return client?.Id ?? 0; 
    }
}