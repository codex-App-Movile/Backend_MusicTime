using Backend_MusicTime.Musician.Domain.Model.Commands;


namespace Backend_MusicTime.Musician.Domain.Services
{
    public interface IArtistCommandService 
    {
        Task<Model.Aggregates.Artist?> Handle(CreateMusicianCommand command);
        Task<Model.Aggregates.Artist?> Handle(UpdateMusicianCommand command);
    }
}

