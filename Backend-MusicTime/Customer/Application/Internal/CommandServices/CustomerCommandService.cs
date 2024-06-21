using Backend_MusicTime.Customer.Domain.Model.Commands;
using Backend_MusicTime.Customer.Domain.Repositories;
using Backend_MusicTime.Customer.Domain.Services;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Customer.Application.Internal.CommandServices;

public class CustomerCommandService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork) : ICustomerCommandService
{
    public async Task<Domain.Model.Aggregates.Customer?> Handle(CreateCustomerCommand command)
    {
        var client = new Domain.Model.Aggregates.Customer(command);
        try
        {
            await customerRepository.AddAsync(client);
            await unitOfWork.CompleteAsync();
            return client;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the client: {e.Message}");
            return null;
        }
    }
}