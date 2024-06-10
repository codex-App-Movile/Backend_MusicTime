using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Model.Queries;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Review.Domain.Services;

namespace Backend_MusicTime.Review.Application.Internal.QueryServices;

public class CommentQueryService(ICommentRepository commentRepository) : ICommentQueryService
{
    public Task<IEnumerable<Comment>> Handle(GetAllCommentsQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> Handle(GetCommentByIdQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Comment>> Handle(GetCommentByUserIdQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Comment>> Handle(GetAllCommentsByBandIdQuery query)
    {
        throw new NotImplementedException();
    }
}
