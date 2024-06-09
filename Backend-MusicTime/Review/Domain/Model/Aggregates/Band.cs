using Backend_MusicTime.Review.Domain.Model.Entities;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Backend_MusicTime.Review.Domain.Model.Aggregates;

public class Band : IEntityWithCreatedUpdatedDate
{
    public int Id { get; set; }
    public string GroupName { get; set; } = default!;
    public ICollection<Comment> Comments { get; } = default!;
    public ICollection<Puntuation> Puntuations { get; } = default!;
    public DateTimeOffset? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTimeOffset? UpdatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Band()
    {
        GroupName = string.Empty;
    }
    public Band(string groupName)
    {
        GroupName = groupName;
    }
}
