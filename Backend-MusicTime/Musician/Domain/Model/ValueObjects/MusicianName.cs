namespace Backend_MusicTime.Musician.Domain.Model.ValueObjects;

public record MusicianName(string FirstName, string Lastname)
{
    public MusicianName() : this(string.Empty, string.Empty) { }
    public MusicianName(string fistName) : this(fistName, string.Empty) { }
    
    public string FullName => $"{FirstName} {Lastname}";
}