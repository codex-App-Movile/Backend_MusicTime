using Backend_MusicTime.IAM.Domain.Model.Aggregates;
using Backend_MusicTime.IAM.Interfaces.REST.Resources;

namespace Backend_MusicTime.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token);
    } 
}