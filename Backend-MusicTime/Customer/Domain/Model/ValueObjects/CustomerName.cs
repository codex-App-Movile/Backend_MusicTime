namespace Backend_MusicTime.Customer.Domain.Model.ValueObjects;

public record CustomerName(string FirstName, string LastName)
{
    public CustomerName() : this(string.Empty, string.Empty)
    {
    }

    public CustomerName(string firstName) : this(firstName, string.Empty)
    {
    }

    public string FullName => $"{FirstName} {LastName}";
}