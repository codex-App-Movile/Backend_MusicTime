using Backend_MusicTime.Musician.Domain.Model.Commands;
using Backend_MusicTime.Musician.Interfaces.REST.Resources;

namespace Backend_MusicTime.Musician.Interfaces.REST.Transform;

public static class CreateArtistCommandFromResourceAssembler
{
    public static CreateMusicianCommand ToCommandFromResource(CreateArtistResource resource)
    {
        return new CreateMusicianCommand(resource.FirstName, resource.LastName, resource.Description, resource.Image,
            resource.GroupMusician);
    }
}