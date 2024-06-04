using Backend_MusicTime.Musician.Domain.Model.Commands;
using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using System.Threading.Tasks;

namespace Backend_MusicTime.Musician.Domain.Services
{
    public interface IArtistCommandService
    {
        Task<Artist?> Handle(CreateMusicianCommand command);
    }
}