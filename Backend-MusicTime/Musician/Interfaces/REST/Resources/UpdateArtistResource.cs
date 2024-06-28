namespace Backend_MusicTime.Musician.Interfaces.REST.Resources;

public record UpdateArtistResource(
    int Id,
    string FirstName, 
    string LastName, 
    string Description, 
    string Image, 
    string GroupMusician);