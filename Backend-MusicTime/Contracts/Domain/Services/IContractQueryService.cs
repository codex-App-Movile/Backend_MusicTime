using Backend_MusicTime.Contracts.Domain.Model.Aggregates;
using Backend_MusicTime.Contracts.Domain.Model.Queries;


namespace Backend_MusicTime.Contracts.Domain.Services
{
    public interface IContractQueryService
    {
        Task<Contract?> Handle(GetContractDetailsQuery query);
        Task<IEnumerable<Contract>> Handle(GetContractsByMusicianQuery query);
        Task<IEnumerable<Contract>> Handle(GetContractsQuery query);
    }
}