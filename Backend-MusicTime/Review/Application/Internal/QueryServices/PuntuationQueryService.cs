using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Model.Queries;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Review.Domain.Services;

namespace Backend_MusicTime.Review.Application.Internal.QueryServices;

public class PuntuationQueryService(IPuntuationRepository puntuationRepository) : IPuntuationQueryService
{
    public Task<IEnumerable<Puntuation>> Handle(GetAllPuntuationsQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Puntuation>> Handle(GetAllPuntuationsByBandIdQuery query)
    {
        throw new NotImplementedException();
    }
}
