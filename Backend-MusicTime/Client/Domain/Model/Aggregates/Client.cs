using Backend_MusicTime.Client.Domain.Model.Commands;
using Backend_MusicTime.Client.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Client.Domain.Model.Aggregates;

public partial class Client
{
    public int Id { get; }
    public ClientName Name { get; private set; }    
    public EmailAddress Email { get; private set; }
    public ClientAddress Address { get; private set; }

    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    public string ClientAddress => Address.FullAddress;

    public Client()
    {
        Name = new ClientName();
        Email = new EmailAddress();
        Address = new ClientAddress();
    }

    public Client(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country)
    {
        Name = new ClientName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new ClientAddress(street, number, city, postalCode, country);
    }

    public Client(CreateClientCommand command)
    {
        Name = new ClientName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Address = new ClientAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);   
    }
}