using Backend_MusicTime.IAM.Domain.Model.Commands;
using Backend_MusicTime.IAM.Interfaces.REST.Resources;

namespace Backend_MusicTime.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }

}