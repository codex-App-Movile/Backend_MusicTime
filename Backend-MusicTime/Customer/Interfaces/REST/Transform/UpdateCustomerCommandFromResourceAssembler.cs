using Backend_MusicTime.Customer.Domain.Model.Commands;
using Backend_MusicTime.Customer.Interfaces.REST.Resources;

namespace Backend_MusicTime.Customer.Interfaces.REST.Transform;

public static class UpdateCustomerCommandFromResourceAssembler
{
    public static UpdateCustomerCommand ToCommandFromResource(UpdateCustomerResource resource, int customerId)
    {
        return new UpdateCustomerCommand(
            Id: customerId,
            FirstName: resource.FirstName,
            LastName: resource.LastName,
            Street: resource.Street,
            Number: resource.Number,
            City: resource.City,
            PostalCode: resource.PostalCode,
            Country: resource.Country   
        );
    }
}