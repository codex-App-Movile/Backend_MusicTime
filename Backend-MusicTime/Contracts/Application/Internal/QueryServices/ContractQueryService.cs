using Backend_MusicTime.Contracts.Domain.Model.Aggregates;
using Backend_MusicTime.Contracts.Domain.Model.Queries;
using Backend_MusicTime.Contracts.Domain.Repositories;

using Backend_MusicTime.Contracts.Domain.Services;

namespace Backend_MusicTime.Contracts.Application.Internal.QueryServices
{
    public class ContractQueryService : IContractQueryService
    {
        private readonly IContractRepository _contractRepository;

        public ContractQueryService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<Contract?> Handle(GetContractDetailsQuery query)
        {
            return await _contractRepository.FindByIdAsync(query.ContractId);
        }

        public async Task<IEnumerable<Contract>> Handle(GetContractsByMusicianQuery query)
        {
            return await _contractRepository.FindByMusicianIdAsync(query.MusicianId);
        }

        public async Task<IEnumerable<Contract>> Handle(GetContractsQuery query)
        {
            return await _contractRepository.ListAsync();
        }
    }
}