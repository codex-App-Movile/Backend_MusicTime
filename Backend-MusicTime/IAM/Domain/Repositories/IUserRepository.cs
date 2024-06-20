using Backend_MusicTime.IAM.Domain.Model.Aggregates;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}