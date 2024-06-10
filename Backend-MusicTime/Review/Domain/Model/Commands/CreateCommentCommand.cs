using Backend_MusicTime.Review.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Review.Domain.Model.Commands;

public record CreateCommentCommand(string Description, BandId BandId, UserId UserId);
