using Backend_MusicTime.Client.Domain.Model.Commands;
using Backend_MusicTime.Client.Domain.Repositories;
using Backend_MusicTime.Client.Domain.Services;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Client.Application.Internal.CommandServices;

public class ClientCommandService(IClientRepository clientRepository, IUnitOfWork unitOfWork) : IClientCommandService
{
    public async Task<Domain.Model.Aggregates.Client?> Handle(CreateClientCommand command)
    {
        var client = new Domain.Model.Aggregates.Client(command);
        try
        {
            await clientRepository.AddAsync(client);
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