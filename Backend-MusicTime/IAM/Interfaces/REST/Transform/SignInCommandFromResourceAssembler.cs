using Backend_MusicTime.IAM.Domain.Model.Commands;
using Backend_MusicTime.IAM.Interfaces.REST.Resources;

namespace Backend_MusicTime.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}