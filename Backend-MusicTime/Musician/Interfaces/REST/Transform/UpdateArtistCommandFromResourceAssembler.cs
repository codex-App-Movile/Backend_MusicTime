using Backend_MusicTime.Musician.Domain.Model.Commands;
using Backend_MusicTime.Musician.Interfaces.REST.Resources;

namespace Backend_MusicTime.Musician.Interfaces.REST.Transform;

public static class UpdateArtistCommandFromResourceAssembler
{
    public static UpdateMusicianCommand ToCommandFromResource(UpdateArtistResource resource, int artistId)
    {
        return new UpdateMusicianCommand(
            Id: artistId,
            FirstName: resource.FirstName,
            LastName: resource.LastName,
            Description: resource.Description,
            Image: resource.Image,
            GroupMusician: resource.GroupMusician
        );
    }
}