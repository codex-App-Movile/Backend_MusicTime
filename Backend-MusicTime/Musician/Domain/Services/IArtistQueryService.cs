using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Musician.Domain.Model.Queries;

namespace Backend_MusicTime.Musician.Domain.Services;

public interface IArtistQueryService
{
    Task<Artist?> Handle(GetMusicianByIdQuery query);
    Task<IEnumerable<Artist>> Handle(GetAllMusicianQuery query);
}