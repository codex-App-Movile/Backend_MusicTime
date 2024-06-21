using Backend_MusicTime.Customer.Interfaces.REST.Resources;

namespace Backend_MusicTime.Customer.Interfaces.REST.Transform;

public static class CustomerResourceFromEntityAssembler
{
    public static CustomerResource ToResourceFromEntity(Customer.Domain.Model.Aggregates.Customer entity)
    {
        return new CustomerResource(entity.Id, entity.FullName, entity.EmailAddress, entity.ClientAddress);
    }   
}