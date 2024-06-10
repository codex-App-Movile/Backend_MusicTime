using Backend_MusicTime.Review.Domain.Model.Aggregates;
using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Model.Queries;

namespace Backend_MusicTime.Review.Domain.Services;

public interface IBandQueryService
{
    Task<IEnumerable<Band>> Handle(GetAllBandsQuery query);
    Task<Band?> Handle(GetBandByIdQuery query);
    Task<IEnumerable<Comment>> Handle(GetAllCommentsByBandIdQuery query);
    Task<IEnumerable<Puntuation>> Handle(GetAllPuntuationsByBandIdQuery query);
}
