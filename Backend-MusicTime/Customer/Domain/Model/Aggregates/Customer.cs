using Backend_MusicTime.Customer.Domain.Model.Commands;
using Backend_MusicTime.Customer.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Customer.Domain.Model.Aggregates;

public partial class Customer
{
    public int Id { get; }
    public CustomerName Name { get; set; }    
    public EmailAddress Email { get; private set; }
    public CustomerAddress Address { get; set; }

    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    public string ClientAddress => Address.FullAddress;

    public Customer()
    {
        Name = new CustomerName();
        Email = new EmailAddress();
        Address = new CustomerAddress();
    }

    public Customer(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country)
    {
        Name = new CustomerName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new CustomerAddress(street, number, city, postalCode, country);
    }

    public Customer(CreateCustomerCommand command)
    {
        Name = new CustomerName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Address = new CustomerAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);   
    }
}