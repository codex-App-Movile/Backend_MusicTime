using Backend_MusicTime.Client.Domain.Model.Commands;
using Backend_MusicTime.Client.Interfaces.REST.Resources;

namespace Backend_MusicTime.Client.Interfaces.REST.Transform;

public static class CreateClientCommandFromResourceAssembler
{
    public static CreateClientCommand ToCommandFromResource(CreateClientResource resource)
    {
        return new CreateClientCommand(resource.FirstName, resource.LastName, resource.Email, resource.Street,
            resource.Number, resource.City, resource.PostalCode, resource.Country);
    }
}