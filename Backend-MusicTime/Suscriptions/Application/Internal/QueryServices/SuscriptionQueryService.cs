using Backend_MusicTime.Shared.Domain.Repositories;
using Backend_MusicTime.Suscriptions.Domain.Model.Aggregates;
using Backend_MusicTime.Suscriptions.Domain.Model.Queries;
using Backend_MusicTime.Suscriptions.Domain.Repositories;
using Backend_MusicTime.Suscriptions.Domain.Services;

namespace Backend_MusicTime.Suscriptions.Application.Internal.QueryServices;

public class SuscriptionQueryService(ISuscriptionRepository suscriptionRepository) : ISuscriptionQueryService
{
    public async Task<IEnumerable<Suscription>> Handle(GetAllSuscriptionsQuery query)
    {
        return await suscriptionRepository.ListAsync();
    }
}