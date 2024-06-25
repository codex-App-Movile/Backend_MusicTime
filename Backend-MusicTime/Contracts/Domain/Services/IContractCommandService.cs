using Backend_MusicTime.Contracts.Domain.Model.Commands;
using Backend_MusicTime.Contracts.Domain.Model.Aggregates;
using System.Threading.Tasks;

namespace Backend_MusicTime.Contracts.Domain.Services
{
    public interface IContractCommandService
    {
        Task<Contract>? Handle(int command);
        Task<Contract>? Handle(UpdateContractCommand command);
        Task<Contract> Handle(CreateContractCommand createContractCommand);
        Task<bool> DeleteContractByIdAsync(DeleteContractCommand command);
        
    }
}