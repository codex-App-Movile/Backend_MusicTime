using Backend_MusicTime.Suscriptions.Domain.Model.Commands;
using Backend_MusicTime.Suscriptions.Interfaces.REST.Resources;

namespace Backend_MusicTime.Suscriptions.Interfaces.REST.Transform;

public static class CreateSuscriptionCommandFromResourceAssembler
{
    public static CreateSuscriptionCommand ToCommandFromResource(CreateSuscriptionResource resource)
    {
        return new CreateSuscriptionCommand(resource.Id, resource.Name, resource.Message, resource.Features,
            resource.Image, resource.Price);
    }
}