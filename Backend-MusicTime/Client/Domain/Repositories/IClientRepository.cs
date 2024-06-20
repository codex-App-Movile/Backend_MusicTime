using Backend_MusicTime.Client.Domain.Model.ValueObjects;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Client.Domain.Repositories;

public interface IClientRepository : IBaseRepository<Model.Aggregates.Client>
{
    Task<Model.Aggregates.Client?> FindClientByEmailAsync(EmailAddress email);
}