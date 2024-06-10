using Backend_MusicTime.Review.Domain.Model.Aggregates;
using Backend_MusicTime.Review.Domain.Model.ValueObjects;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Backend_MusicTime.Review.Domain.Model.Entities;

public class Puntuation : IEntityWithCreatedUpdatedDate
{
    public int Id { get; }
    public int Score { get; set; } = default!;
    public int BandId { get; set; } = default!;
    public Band Band { get; set; } = default!;
    public int UserId { get; set; } = default!;
    public DateTimeOffset? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTimeOffset? UpdatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Puntuation() { }

    public Puntuation(int score, int bandId, int userId)
    {
        Score = score;
        BandId = bandId;
        UserId = userId;
    }
    //public Puntuation(int score, BandId bandId, UserId userId)
    //{
    //    Score = score;
    //    BandId = bandId;
    //    UserId = userId;
    //}
}
