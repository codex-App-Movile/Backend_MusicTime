namespace Backend_MusicTime.Customer.Domain.Model.ValueObjects;

public record CustomerAddress(string Street, string Number, string City, string PostalCode, string Country)
{
    public CustomerAddress() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }

    public CustomerAddress(string street) : this(street, string.Empty, string.Empty, string.Empty,
        string.Empty)
    {
    }

    public CustomerAddress(string street, string number, string city) : this(street, number, city,
        string.Empty, string.Empty)
    {
    }

    public CustomerAddress(string street, string number, string city, string postalCode) : this(street, number, city, postalCode,
        string.Empty)
    {
    }

    public string FullAddress => $"{Street} {Number}, {City}, {PostalCode}, {Country}";
}