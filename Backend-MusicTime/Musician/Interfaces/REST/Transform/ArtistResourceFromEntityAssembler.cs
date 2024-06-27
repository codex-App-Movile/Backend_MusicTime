using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Musician.Interfaces.REST.Resources;

namespace Backend_MusicTime.Musician.Interfaces.REST.Transform;

public class ArtistResourceFromEntityAssembler
{
    public static ArtistResource ToResourceFromEntity(Artist entity)
    {
        return new ArtistResource(entity.Id, entity.FullName, entity.Description, entity.Image, entity.GroupMusician);
    }
}