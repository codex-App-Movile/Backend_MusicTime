using Backend_MusicTime.Enterprise.Domain.Model.ValueObjects;
using Backend_MusicTime.Enterprise.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_MusicTime.Enterprise.Infrastructure.Persistence.EFC.Repositories;

public class EnterpriseRepository(AppDbContext context) : BaseRepository<Domain.Model.Aggregates.Enterprise>(context), IEnterpriseRepository
{
    public Task<Domain.Model.Aggregates.Enterprise?> FindEnterpriseByNameAsync(EnterpriseName name)
    {
        return Context.Set<Domain.Model.Aggregates.Enterprise>().Where(e => e.Name == name).FirstOrDefaultAsync();
    }
    
    public Task<Domain.Model.Aggregates.Enterprise?> FindEnterpriseByEmailAsync(EnterpriseEmailAddress email)
    {
        return Context.Set<Domain.Model.Aggregates.Enterprise>().Where(e => e.Email == email).FirstOrDefaultAsync();
    }
}