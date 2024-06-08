namespace Backend_MusicTime.Review.Domain.Model.ValueObjects;

public record BandId
{
    int bandId { get; }
    public BandId(int bandId)
    {
        if (bandId < 0)
        {
            throw new ArgumentOutOfRangeException("User ID cannot be negative", nameof(bandId));
        }
        this.bandId = bandId;
    }
}
