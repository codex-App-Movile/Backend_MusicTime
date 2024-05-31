using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Musician.Domain.Model.Commands;

namespace Backend_MusicTime.Musician.Domain.Services;

public interface IArtistCommandService
{
    Task<Artist?> Handle(CreateMusicianCommand command);
}