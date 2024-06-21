using Backend_MusicTime.Customer.Domain.Model.Commands;
using Backend_MusicTime.Customer.Domain.Model.Queries;
using Backend_MusicTime.Customer.Domain.Model.ValueObjects;
using Backend_MusicTime.Customer.Domain.Services;

namespace Backend_MusicTime.Customer.Interfaces.ACL.Services;

public class CustomersContextFacade(ICustomerCommandService customerCommandService, ICustomerQueryService customerQueryService) : ICustomersContextFacade
{
    public async Task<int> CreateClient(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country)
    {
        var createClientCommand = new CreateCustomerCommand(firstName, lastName, email, street, number, city, postalCode, country);
        var client = await customerCommandService.Handle(createClientCommand);
        return client?.Id ?? 0;
    }

    public async Task<int> FetchClientIdByEmail(string email)
    {
        var getClientByEmailQuery = new GetCustomerByEmailQuery(new EmailAddress(email));
        var client = await customerQueryService.Handle(getClientByEmailQuery);
        return client?.Id ?? 0; 
    }
}