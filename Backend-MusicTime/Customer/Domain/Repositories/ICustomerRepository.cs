using Backend_MusicTime.Customer.Domain.Model.ValueObjects;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Customer.Domain.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer.Domain.Model.Aggregates.Customer>
{
    Task<Customer.Domain.Model.Aggregates.Customer?> FindClientByEmailAsync(EmailAddress email);
}