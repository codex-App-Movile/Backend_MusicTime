using Backend_MusicTime.Review.Domain.Model.Aggregates;
using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_MusicTime.Review.Infrastructure.Persistence.EFC.Repositories;

public class BandRepository(AppDbContext context) : BaseRepository<Band>(context), IBandRepository
{
    public async Task<IEnumerable<Comment>> GetCommentsByBandId(int bandId)
    {
        return await Context.Comments.Where(c => c.BandId == bandId).ToListAsync();
    }

    public async Task<IEnumerable<Puntuation>> GetPuntuationsByBandId(int bandId)
    {
        return await Context.Puntuations.Where(p => p.BandId == bandId).ToListAsync();
    }
}
