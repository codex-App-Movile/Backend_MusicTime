using Backend_MusicTime.Review.Domain.Model.Aggregates;
using Backend_MusicTime.Review.Domain.Model.ValueObjects;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Backend_MusicTime.Review.Domain.Model.Entities;

public class Comment : IEntityWithCreatedUpdatedDate
{
    public int Id { get; }
    public string Description { get; set; } = default!;
    public DateTime Date { get; set; } = default!;
    public DateTimeOffset? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTimeOffset? UpdatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Comment() { }
    public Comment(string description)
    {
        Description = description;
        Date = DateTime.Now;
    }
}
