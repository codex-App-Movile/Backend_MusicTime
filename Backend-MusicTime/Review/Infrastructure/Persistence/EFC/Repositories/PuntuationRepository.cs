using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_MusicTime.Review.Infrastructure.Persistence.EFC.Repositories;

public class PuntuationRepository(AppDbContext context) : BaseRepository<Puntuation>(context), IPuntuationRepository
{
    public async Task<IEnumerable<Puntuation>> GetPuntuationsByBandId(int bandId)
    {
        return await Context.Puntuations.Where(p => p.BandId == bandId).ToListAsync();
    }
}
