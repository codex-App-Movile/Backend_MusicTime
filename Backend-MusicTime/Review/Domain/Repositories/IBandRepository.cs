using Backend_MusicTime.Review.Domain.Model.Aggregates;
using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Review.Domain.Repositories;

public interface IBandRepository : IBaseRepository<Band>
{
    Task<IEnumerable<Comment>> GetCommentsByBandId(int bandId);
    Task<IEnumerable<Puntuation>> GetPuntuationsByBandId(int bandId);
}
