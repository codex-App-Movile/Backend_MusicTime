namespace Backend_MusicTime.Client.Domain.Model.ValueObjects;

public record ClientName(string FirstName, string LastName)
{
    public ClientName() : this(string.Empty, string.Empty)
    {
    }

    public ClientName(string firstName) : this(firstName, string.Empty)
    {
    }

    public string FullName => $"{FirstName} {LastName}";
}