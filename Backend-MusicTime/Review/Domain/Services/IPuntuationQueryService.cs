using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Model.Queries;

namespace Backend_MusicTime.Review.Domain.Services;

public interface IPuntuationQueryService
{
    Task<IEnumerable<Puntuation>> Handle(GetAllPuntuationsQuery query);
    Task<IEnumerable<Puntuation>> Handle(GetAllPuntuationsByBandIdQuery query);
}
