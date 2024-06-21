using Backend_MusicTime.Customer.Domain.Model.Queries;

namespace Backend_MusicTime.Customer.Domain.Services;

public interface ICustomerQueryService
{
    Task<IEnumerable<Customer.Domain.Model.Aggregates.Customer>> Handle(GetAllCustomersQuery query);
    Task<Customer.Domain.Model.Aggregates.Customer?> Handle(GetCustomerByEmailQuery query);
    Task<Customer.Domain.Model.Aggregates.Customer?> Handle(GetCustomerByIdQuery query);
}