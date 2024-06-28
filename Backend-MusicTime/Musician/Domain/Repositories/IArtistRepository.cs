using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Shared.Domain.Repositories;


namespace Backend_MusicTime.Musician.Domain.Repositories;

public interface IArtistRepository : IBaseRepository<Model.Aggregates.Artist>
{
    Task<Artist?> FindArtistByGroupAsync(Guid groupMusician);
    Task<Artist?> GetByIdAsync(int id);
    Task UpdateAsync(Artist artist);
}