namespace Backend_MusicTime.Review.Domain.Model.ValueObjects;

public record UserId
{
    public int Value {  get; }
    public UserId(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("User ID cannot be negative", nameof(value));
        }
        this.Value = value;
    }
}

