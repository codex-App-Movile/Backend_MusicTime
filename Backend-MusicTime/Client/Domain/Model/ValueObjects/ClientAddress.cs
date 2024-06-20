namespace Backend_MusicTime.Client.Domain.Model.ValueObjects;

public record ClientAddress(string Street, string Number, string City, string PostalCode, string Country)
{
    public ClientAddress() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }

    public ClientAddress(string street) : this(street, string.Empty, string.Empty, string.Empty,
        string.Empty)
    {
    }

    public ClientAddress(string street, string number, string city) : this(street, number, city,
        string.Empty, string.Empty)
    {
    }

    public ClientAddress(string street, string number, string city, string postalCode) : this(street, number, city, postalCode,
        string.Empty)
    {
    }

    public string FullAddress => $"{Street} {Number}, {City}, {PostalCode}, {Country}";
}