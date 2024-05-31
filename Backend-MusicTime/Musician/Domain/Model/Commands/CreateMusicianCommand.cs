namespace Backend_MusicTime.Musician.Domain.Model.Commands;

public record CreateMusicianCommand( string FirstName, string LastName, string Description, string Image,string GroupMusician);