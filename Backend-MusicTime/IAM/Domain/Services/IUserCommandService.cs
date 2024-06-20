using Backend_MusicTime.IAM.Domain.Model.Aggregates;
using Backend_MusicTime.IAM.Domain.Model.Commands;

namespace Backend_MusicTime.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}