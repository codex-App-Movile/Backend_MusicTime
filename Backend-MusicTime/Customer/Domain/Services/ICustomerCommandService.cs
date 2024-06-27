using Backend_MusicTime.Customer.Domain.Model.Commands;

namespace Backend_MusicTime.Customer.Domain.Services;

public interface ICustomerCommandService
{
    Task<Customer.Domain.Model.Aggregates.Customer?> Handle(CreateCustomerCommand command);
    Task<Model.Aggregates.Customer?> Handle(UpdateCustomerCommand command); 
}