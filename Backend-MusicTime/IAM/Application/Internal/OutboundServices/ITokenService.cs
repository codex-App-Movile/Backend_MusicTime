using Backend_MusicTime.IAM.Domain.Model.Aggregates;

namespace Backend_MusicTime.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}