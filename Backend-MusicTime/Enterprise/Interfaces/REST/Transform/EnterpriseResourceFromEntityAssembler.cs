using Backend_MusicTime.Enterprise.Interfaces.REST.Resources;

namespace Backend_MusicTime.Enterprise.Interfaces.REST.Transform;

public static class EnterpriseResourceFromEntityAssembler
{
    public static EnterpriseResource ToResourceFromEntity(Enterprise.Domain.Model.Aggregates.Enterprise entity)
    {
        return new EnterpriseResource(entity.Id, entity.EnterpriseName, entity.EmailAddress, entity.EnterpriseAddress);
    }
}