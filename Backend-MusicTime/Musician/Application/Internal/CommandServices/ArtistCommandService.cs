using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Musician.Domain.Model.Commands;
using Backend_MusicTime.Musician.Domain.Model.ValueObjects;
using Backend_MusicTime.Musician.Domain.Repositories;
using Backend_MusicTime.Musician.Domain.Services;
using Backend_MusicTime.Shared.Domain.Repositories;


namespace Backend_MusicTime.Musician.Application.Internal.CommandServices;

public class ArtistCommandService(IArtistRepository artistRepository, IUnitOfWork unitOfWork) : IArtistCommandService
{
    public async Task<Domain.Model.Aggregates.Artist?> Handle(CreateMusicianCommand command)
    {
        var artist = new Domain.Model.Aggregates.Artist(command);
        try
        {
            await artistRepository.AddAsync(artist);
            await unitOfWork.CompleteAsync();
            return artist;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the artist: {e.Message}");
            return null;
        }
    }

    public async Task<Domain.Model.Aggregates.Artist?> Handle(UpdateMusicianCommand command)
    {
        var artist = await artistRepository.GetByIdAsync(command.Id);
        if (artist == null)
        {
            Console.WriteLine("Artist not found.");
            return null;
        }

        artist.Name = new MusicianName(command.FirstName, command.LastName);
        artist.Description = command.Description;
        artist.Image = command.Image;
        artist.GroupMusician = command.GroupMusician;

        try
        {
            await artistRepository.UpdateAsync(artist);
            await unitOfWork.CompleteAsync();
            return artist;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the artist: {e.Message}");
            return null;
        }
    }
}


