using Backend_MusicTime.Client.Domain.Model.Queries;
using Backend_MusicTime.Client.Domain.Repositories;
using Backend_MusicTime.Client.Domain.Services;

namespace Backend_MusicTime.Client.Application.Internal.QueryServices;

public class ClientQueryService(IClientRepository clientRepository) : IClientQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Client>> Handle(GetAllClientsQuery query)
    {
        return await clientRepository.ListAsync();
    }

    public async Task<Domain.Model.Aggregates.Client?> Handle(GetClientByEmailQuery query)
    {
        return await clientRepository.FindClientByEmailAsync(query.Email);
    }

    public async Task<Domain.Model.Aggregates.Client?> Handle(GetClientByIdQuery query)
    {
        return await clientRepository.FindByIdAsync(query.ClientId);    
    }
}