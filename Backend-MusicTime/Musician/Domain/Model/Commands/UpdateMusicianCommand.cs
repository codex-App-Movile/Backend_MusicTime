namespace Backend_MusicTime.Musician.Domain.Model.Commands;

public record UpdateMusicianCommand( int Id, string FirstName, string LastName, string Description, string Image,string GroupMusician);