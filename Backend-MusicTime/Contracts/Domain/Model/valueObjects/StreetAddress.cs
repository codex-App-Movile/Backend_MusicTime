namespace Backend_MusicTime.Contracts.Domain.Model.ValueObjects;

public record StreetAddress(string Street, string Number, string City)
{
    public StreetAddress() : this(string.Empty, string.Empty, string.Empty)
    {
    }

    public StreetAddress(string street, string number) : this(street, number, string.Empty)
    {
    }

    public string FullAddress => $"{Street} {Number}, {City}";
}