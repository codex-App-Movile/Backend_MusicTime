namespace Backend_MusicTime.Enterprise.Domain.Model.ValueObjects;

public record EnterpriseAddress(string Street, string Number, string City, string PostalCode, string Country)
{
    public EnterpriseAddress() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }

    public EnterpriseAddress(string street) : this(street, string.Empty, string.Empty, string.Empty,
        string.Empty)
    {
    }

    public EnterpriseAddress(string street, string number, string city) : this(street, number, city,
        string.Empty, string.Empty)
    {
    }

    public EnterpriseAddress(string street, string number, string city, string postalCode) : this(street, number, city, postalCode,
        string.Empty)
    {
    }

    public string FullAddress => $"{Street} {Number}, {City}, {PostalCode}, {Country}";
}