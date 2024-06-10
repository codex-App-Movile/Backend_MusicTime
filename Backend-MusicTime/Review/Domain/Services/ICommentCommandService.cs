using Backend_MusicTime.Review.Domain.Model.Commands;
using Backend_MusicTime.Review.Domain.Model.Entities;

namespace Backend_MusicTime.Review.Domain.Services;

public interface ICommentCommandService
{
    Task<Comment?> Handle(CreateCommentCommand command);
}
