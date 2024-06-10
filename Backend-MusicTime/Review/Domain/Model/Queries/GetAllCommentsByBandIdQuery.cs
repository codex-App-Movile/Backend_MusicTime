using Backend_MusicTime.Review.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Review.Domain.Model.Queries;

public record GetAllCommentsByBandIdQuery(BandId BandId);
