namespace Backend_MusicTime.Musician.Domain.Model.ValueObjects;

public record MusicianName(string FirstName, string LastName)
{
    public MusicianName() : this(string.Empty, string.Empty)
    {
    }

    public MusicianName(string firstName) : this(firstName, string.Empty)
    {
    }

    public string FullName => $"{FirstName} {LastName}";
}