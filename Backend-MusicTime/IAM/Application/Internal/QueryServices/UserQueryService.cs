using Backend_MusicTime.IAM.Domain.Model.Aggregates;
using Backend_MusicTime.IAM.Domain.Model.Queries;
using Backend_MusicTime.IAM.Domain.Repositories;
using Backend_MusicTime.IAM.Domain.Services;

namespace Backend_MusicTime.IAM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}