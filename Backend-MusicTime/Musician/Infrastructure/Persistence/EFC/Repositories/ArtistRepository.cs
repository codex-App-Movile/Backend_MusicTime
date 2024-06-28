
using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Musician.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_MusicTime.Musician.Infrastructure.Persistence.EFC.Repositories;

public class ArtistRepository(AppDbContext context) : BaseRepository<Artist>(context), IArtistRepository
{
    public Task<Artist?> FindArtistByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    
    public override async Task<Artist?> FindByIdAsync(int id)
    {
        return await context.Artists.FindAsync(id);
    }

    public Task<Artist?> FindArtistByGroupAsync(Guid groupMusician)
    {
        throw new NotImplementedException();
    }

    public async Task<Artist?> GetByIdAsync(int id)
    {
        return await context.Artists.FindAsync(id);
    }

    public async Task UpdateAsync(Artist artist)
    {
        context.Entry(artist).State = EntityState.Modified;
        
        await context.SaveChangesAsync();
    }
}
