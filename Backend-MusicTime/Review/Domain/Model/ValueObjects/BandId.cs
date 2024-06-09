namespace Backend_MusicTime.Review.Domain.Model.ValueObjects;

public record BandId
{
    public int Value { get; set; }
    public BandId(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("User ID cannot be negative", nameof(value));
        }
        this.Value = Value;
    }
}
