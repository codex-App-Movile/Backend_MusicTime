using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Model.Queries;

namespace Backend_MusicTime.Review.Domain.Services;

public interface ICommentQueryService
{
    Task<IEnumerable<Comment>> Handle(GetAllCommentsQuery query);
    Task<Comment?> Handle(GetCommentByIdQuery query);
    Task<IEnumerable<Comment>> Handle(GetCommentByUserIdQuery query);
    Task<IEnumerable<Comment>> Handle(GetAllCommentsByBandIdQuery query);
}
