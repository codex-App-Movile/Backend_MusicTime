using Backend_MusicTime.Customer.Domain.Model.Queries;
using Backend_MusicTime.Customer.Domain.Repositories;
using Backend_MusicTime.Customer.Domain.Services;

namespace Backend_MusicTime.Customer.Application.Internal.QueryServices;

public class CustomerQueryService(ICustomerRepository customerRepository) : ICustomerQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Customer>> Handle(GetAllCustomersQuery query)
    {
        return await customerRepository.ListAsync();
    }

    public async Task<Domain.Model.Aggregates.Customer?> Handle(GetCustomerByEmailQuery query)
    {
        return await customerRepository.FindClientByEmailAsync(query.Email);
    }

    public async Task<Domain.Model.Aggregates.Customer?> Handle(GetCustomerByIdQuery query)
    {
        return await customerRepository.FindByIdAsync(query.ClientId);    
    }
}