using Backend_MusicTime.Client.Interfaces.REST.Resources;

namespace Backend_MusicTime.Client.Interfaces.REST.Transform;

public static class ClientResourceFromEntityAssembler
{
    public static ClientResource ToResourceFromEntity(Domain.Model.Aggregates.Client entity)
    {
        return new ClientResource(entity.Id, entity.FullName, entity.EmailAddress, entity.ClientAddress);
    }   
}