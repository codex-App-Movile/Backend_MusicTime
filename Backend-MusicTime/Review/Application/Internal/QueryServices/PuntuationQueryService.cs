using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Model.Queries;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Review.Domain.Services;

namespace Backend_MusicTime.Review.Application.Internal.QueryServices;

public class PuntuationQueryService(IPuntuationRepository puntuationRepository) : IPuntuationQueryService
{
    public async Task<IEnumerable<Puntuation>> Handle(GetAllPuntuationsQuery query) => await puntuationRepository.ListAsync();

    public async Task<IEnumerable<Puntuation>> Handle(GetAllPuntuationsByBandIdQuery query) => await puntuationRepository.GetPuntuationsByBandId(query.BandId.Value);
}
