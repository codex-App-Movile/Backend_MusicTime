using Backend_MusicTime.Review.Domain.Model.Aggregates;
using Backend_MusicTime.Review.Domain.Model.Commands;

namespace Backend_MusicTime.Review.Domain.Services;

public interface IBandCommandService
{
    Task<Band?> Handle(CreateBandCommand command);
}
