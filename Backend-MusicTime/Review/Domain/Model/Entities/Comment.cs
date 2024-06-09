﻿using Backend_MusicTime.Review.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Review.Domain.Model.Entities;

public partial class Comment
{
    public int Id { get; }
    public string Description { get; set; } = default!;
    public UserId UserId { get; } = default!;
    public BandId BandId { get; } = default!;
    public DateTime Date { get; set; } = default!;

}
