using Backend_MusicTime.Client.Domain.Model.ValueObjects;
using Backend_MusicTime.Client.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_MusicTime.Client.Infrastructure.Persistence.EFC.Repositories;

public class ClientRepository(AppDbContext context) : BaseRepository<Domain.Model.Aggregates.Client>(context), IClientRepository
{
    public Task<Domain.Model.Aggregates.Client?> FindClientByEmailAsync(EmailAddress email)
    {
        return Context.Set<Domain.Model.Aggregates.Client>().Where(c => c.Email == email).FirstOrDefaultAsync();    
    }
}