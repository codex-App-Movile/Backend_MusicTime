using Backend_MusicTime.Contracts.Domain.Model.Aggregates;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Contracts.Domain.Repositories;

public interface IContractRepository : IBaseRepository<Contract>
{
    Task<Contract?> FindContractByIdAsync(int id);
    Task<IEnumerable<Contract>> FindByMusicianIdAsync(int queryMusicianId);
}