using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Musician.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Backend_MusicTime.Musician.Infrastructure.Persistence.EFC.Repositories;

public class ArtistRepository(AppDbContext context) : BaseRepository<Artist>(context), IArtistRepository
{
    public Task<Artist?> FindArtistByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
