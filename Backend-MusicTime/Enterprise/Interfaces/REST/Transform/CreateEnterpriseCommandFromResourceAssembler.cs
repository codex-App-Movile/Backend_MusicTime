using Backend_MusicTime.Enterprise.Domain.Model.Commands;
using Backend_MusicTime.Enterprise.Interfaces.REST.Resources;

namespace Backend_MusicTime.Enterprise.Interfaces.REST.Transform;

public static class CreateEnterpriseCommandFromResourceAssembler
{
    public static CreateEnterpriseCommand ToCommandFromResource(CreateEnterpriseResource resource)
    {
        return new CreateEnterpriseCommand(resource.Name, resource.Email, resource.Street, resource.Number, resource.City, resource.PostalCode, resource.Country);
    }
}