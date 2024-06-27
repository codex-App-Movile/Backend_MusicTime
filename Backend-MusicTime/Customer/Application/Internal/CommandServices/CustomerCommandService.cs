using Backend_MusicTime.Customer.Domain.Model.Commands;
using Backend_MusicTime.Customer.Domain.Model.ValueObjects;
using Backend_MusicTime.Customer.Domain.Repositories;
using Backend_MusicTime.Customer.Domain.Services;
using Backend_MusicTime.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_MusicTime.Customer.Application.Internal.CommandServices;

public class CustomerCommandService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork) : ICustomerCommandService
{
    public async Task<Domain.Model.Aggregates.Customer?> Handle(CreateCustomerCommand command)
    {
        var client = new Domain.Model.Aggregates.Customer(command);
        try
        {
            await customerRepository.AddAsync(client);
            await unitOfWork.CompleteAsync();
            return client;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the client: {e.Message}");
            return null;
        }
    }

    public async Task<Domain.Model.Aggregates.Customer?> Handle(UpdateCustomerCommand command)
    {
        try
        {
            var customer = await customerRepository.FindByIdAsync(command.Id);
            if (customer == null)
            {
                Console.WriteLine($"Customer with ID {command.Id} not found.");
                return null;
            }

            customer.Name = new CustomerName(command.FirstName, command.LastName);
            customer.Address = new CustomerAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);
            
            customerRepository.Update(customer);
            await unitOfWork.CompleteAsync();
            Console.WriteLine($"Customer with ID {command.Id} updated successfully.");
            return customer;
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine($"A database error occurred while updating the customer: {e.Message}");
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An unexpected error occurred while updating the customer: {e.Message}");
            return null;
        }
    }
}