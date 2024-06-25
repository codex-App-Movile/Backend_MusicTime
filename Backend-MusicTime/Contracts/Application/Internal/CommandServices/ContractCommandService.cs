using Backend_MusicTime.Contracts.Domain.Model.Aggregates;
using Backend_MusicTime.Contracts.Domain.Model.Commands;
using Backend_MusicTime.Contracts.Domain.Repositories;
using Backend_MusicTime.Shared.Domain.Repositories;

using Backend_MusicTime.Contracts.Domain.Model.ValueObjects;
using Backend_MusicTime.Contracts.Domain.Services;
using Microsoft.EntityFrameworkCore;

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
            var terms = command.Reason;

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

        public async Task<bool> DeleteContractByIdAsync(DeleteContractCommand command)
        {
            try
            {
                var contract = await _contractRepository.FindByIdAsync(command.Id);
                if (contract == null)
                {
                    Console.WriteLine($"Contract with ID {command.Id} not found.");
                    return false;
                }

                _contractRepository.Remove(contract);
                await _unitOfWork.CompleteAsync();
                Console.WriteLine($"Contract with ID {command.Id} deleted successfully.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while deleting the contract: {e.Message}");
                return false;
            }
        }

        public async Task<Contract>? Handle(int contractId)
        {
            var contract = await _contractRepository.FindByIdAsync(contractId);
            if (contract == null)
            {
                Console.WriteLine($"Contract with ID {contractId} not found.");
                return null;
            }

            return contract;
        }

public async Task<Contract>? Handle(UpdateContractCommand command)
{
    try
    {
        var contract = await _contractRepository.FindByIdAsync(command.Id);
        if (contract == null)
        {
            Console.WriteLine($"Contract with ID {command.Id} not found.");
            return null;
        }

        contract.EventDate = command.EventDate;
        contract.EventLocation = new StreetAddress(command.Street, command.Number, command.City);

        _contractRepository.Update(contract);
        await _unitOfWork.CompleteAsync();
        Console.WriteLine($"Contract with ID {command.Id} updated successfully.");
        return contract;
    }
    catch (DbUpdateException e)
    {
        Console.WriteLine($"A database error occurred while updating the contract: {e.Message}");
        return null;
    }
    catch (Exception e)
    {
        Console.WriteLine($"An unexpected error occurred while updating the contract: {e.Message}");
        return null;
    }
}
    }
}