using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Model.Queries;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Review.Domain.Services;

namespace Backend_MusicTime.Review.Application.Internal.QueryServices;

public class CommentQueryService(ICommentRepository commentRepository) : ICommentQueryService
{
    public async Task<IEnumerable<Comment>> Handle(GetAllCommentsQuery query) => await commentRepository.ListAsync();

    public async Task<Comment?> Handle(GetCommentByIdQuery query) => await commentRepository.FindByIdAsync(query.id);

    public async Task<IEnumerable<Comment>> Handle(GetCommentByUserIdQuery query) => await commentRepository.GetAllCommentsByUserId(query.UserId.Value);

    public async Task<IEnumerable<Comment>> Handle(GetAllCommentsByBandIdQuery query) => await commentRepository.GetCommentsByBandId(query.BandId.Value);
}
