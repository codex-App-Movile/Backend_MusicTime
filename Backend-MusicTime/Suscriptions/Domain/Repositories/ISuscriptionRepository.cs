using Backend_MusicTime.Shared.Domain.Repositories;
using Backend_MusicTime.Suscriptions.Domain.Model.Aggregates;

namespace Backend_MusicTime.Suscriptions.Domain.Repositories;

public interface ISuscriptionRepository : IBaseRepository<Suscription>
{
    Task<Suscription?> FindSuscriptionByIdAsync(int id);
}