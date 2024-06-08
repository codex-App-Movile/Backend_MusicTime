namespace Backend_MusicTime.Feedback.Domain.Model.ValueObjects;

public record UserId
{
    int userId {  get; }
    public UserId(int userId)
    {
        if (userId < 0)
        {
            throw new ArgumentOutOfRangeException("User ID cannot be negative", nameof(userId));
        }
        this.userId = userId;
    }
}

