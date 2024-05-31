using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Musician.Domain.Repositories;
using Backend_MusicTime.Musician.Domain.Model.ValueObjects;


namespace Backend_MusicTime.Musician.Domain.Repositories;

public interface IArtistRepository
{
    Task<Artist?> FindArtistByIdAsync(Guid id);
}