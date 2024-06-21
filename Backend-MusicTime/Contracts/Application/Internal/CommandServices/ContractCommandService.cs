using Backend_MusicTime.Contracts.Domain.Model.Aggregates;
using Backend_MusicTime.Contracts.Domain.Model.Commands;
using Backend_MusicTime.Contracts.Domain.Repositories;
using Backend_MusicTime.Shared.Domain.Repositories;

using Backend_MusicTime.Contracts.Domain.Model.ValueObjects;
using Backend_MusicTime.Contracts.Domain.Services;

namespace Backend_MusicTime.Contracts.Application.Internal.CommandServices
{
    public class ContractCommandService : IContractCommandService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContractCommandService(IContractRepository contractRepository, IUnitOfWork unitOfWork)
        {
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Contract> Handle(CreateContractCommand command)
        {
            var customerName = new PersonName(command.CustomerFirstName, command.CustomerLastName);
            var musicianName = new PersonName(command.MusicianFirstName, command.MusicianLastName);
            var terms = command.Terms;

            var contract = new Contract(command, customerName, musicianName, terms);
            try
            {
                await _contractRepository.AddAsync(contract);
                await _unitOfWork.CompleteAsync();
                return contract;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the contract: {e.Message}");
                return null;
            }
        }

        public Task<Contract>? Handle(int command)
        {
            throw new NotImplementedException();
        }

        public async Task<Contract>? Handle(UpdateContractCommand command)
        {
            var contract = await _contractRepository.FindByIdAsync(command.Id);
            if (contract == null)
            {
                return null;
            }

            contract.EventDate = command.EventDate;
            contract.EventLocation = new StreetAddress(command.Street, command.Number, command.City);

            try
            {
                _contractRepository.Update(contract);
                await _unitOfWork.CompleteAsync();
                return contract;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while updating the contract: {e.Message}");
                return null;
            }
        }
    }
}