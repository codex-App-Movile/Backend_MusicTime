using Backend_MusicTime.Review.Domain.Model.Commands;
using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Review.Domain.Services;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Review.Application.Internal.CommandServices;

public class CommentCommandService(ICommentRepository commentRepository, IUnitOfWork unitOfWork) : ICommentCommandService
{
    public Task<Comment?> Handle(CreateCommentCommand command)
    {
        throw new NotImplementedException();
    }
}
