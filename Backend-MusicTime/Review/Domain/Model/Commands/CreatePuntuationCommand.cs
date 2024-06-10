using Backend_MusicTime.Review.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Review.Domain.Model.Commands;

public record CreatePuntuationCommand(int Score, BandId BandId, UserId UserId);