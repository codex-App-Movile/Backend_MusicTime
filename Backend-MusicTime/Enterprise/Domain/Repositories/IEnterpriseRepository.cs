using Backend_MusicTime.Enterprise.Domain.Model.ValueObjects;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Enterprise.Domain.Repositories;

public interface IEnterpriseRepository : IBaseRepository<Model.Aggregates.Enterprise>
{
    Task<Model.Aggregates.Enterprise?> FindEnterpriseByEmailAsync(EnterpriseEmailAddress email);
}