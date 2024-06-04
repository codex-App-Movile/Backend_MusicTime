using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Musician.Domain.Model.Commands;
using Backend_MusicTime.Musician.Domain.Repositories;
using Backend_MusicTime.Musician.Domain.Services;
using Backend_MusicTime.Shared.Domain.Repositories;


namespace Backend_MusicTime.Musician.Application.Internal.CommandServices;

//public class ArtistCommandService(IArtistRepository artistRepository, IUnitOfWork unitOfWork) : IArtistCommandService
//{
    //public async Task<Artist?> Handle(CreateMusicianCommand command)
    //{
        // var artist = new Artist(command);
        // try
       // {
            //await artistRepository.AddAsync(artist);
            //await unitOfWork.CompleteAsync();
            //return artist;
       // } catch (Exception e)
       // {
            //Console.WriteLine($"An error occurred while creating the artist: {e.Message}");
            //return null;
       // }
    //}
//}


