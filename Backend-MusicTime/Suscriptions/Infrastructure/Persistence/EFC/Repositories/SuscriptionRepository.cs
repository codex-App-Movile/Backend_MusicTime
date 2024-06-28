using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_MusicTime.Suscriptions.Domain.Model.Aggregates;
using Backend_MusicTime.Suscriptions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_MusicTime.Suscriptions.Infrastructure.Persistence.EFC.Repositories;

public class SuscriptionRepository : BaseRepository<Suscription>, ISuscriptionRepository
{
    private readonly AppDbContext context;
    public SuscriptionRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }

    public Task<Suscription?> FindSuscriptionByIdAsync(int id)
    {
        return Context.Set<Suscription>().Where(s => s.Id == id).FirstOrDefaultAsync();
    }
}