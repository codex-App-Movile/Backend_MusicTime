using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Musician.Domain.Repositories;
using Backend_MusicTime.Musician.Domain.Model.ValueObjects;
using Backend_MusicTime.Shared.Domain.Repositories;


namespace Backend_MusicTime.Musician.Domain.Repositories;

public interface IArtistRepository : IBaseRepository<Artist>
{
    Task<Artist?> FindArtistByIdAsync(Guid id);
}