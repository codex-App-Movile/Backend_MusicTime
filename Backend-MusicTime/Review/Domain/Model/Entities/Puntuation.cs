using Backend_MusicTime.Review.Domain.Model.ValueObjects;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Backend_MusicTime.Review.Domain.Model.Entities;

public class Puntuation : IEntityWithCreatedUpdatedDate
{
    public int Id { get; }
    public int Score { get; set; } = default!;
    public DateTimeOffset? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTimeOffset? UpdatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Puntuation() { }

    public Puntuation(int score)
    {
        Score = score;
    }
}
