using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Review.Domain.Repositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<IEnumerable<Comment>> GetAllCommentsByUserId(int userId);
    Task<IEnumerable<Comment>> GetCommentsByBandId(int bandId);
}
