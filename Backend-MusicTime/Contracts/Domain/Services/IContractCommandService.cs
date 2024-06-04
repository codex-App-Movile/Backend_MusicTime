using Backend_MusicTime.Contracts.Domain.Model.Commands;
using Backend_MusicTime.Contracts.Domain.Model.Aggregates;

namespace Backend_MusicTime.Contracts.Domain.Services;

public interface IContractCommandService
    {
        Task<Contract>? Handle(CreateContractCommand command);
    }
