using Backend_MusicTime.Customer.Domain.Model.Commands;
using Backend_MusicTime.Customer.Interfaces.REST.Resources;

namespace Backend_MusicTime.Customer.Interfaces.REST.Transform;

public static class CreateCustomerCommandFromResourceAssembler
{
    public static CreateCustomerCommand ToCommandFromResource(CreateCustomerResource resource)
    {
        return new CreateCustomerCommand(resource.FirstName, resource.LastName, resource.Email, resource.Street,
            resource.Number, resource.City, resource.PostalCode, resource.Country);
    }
}