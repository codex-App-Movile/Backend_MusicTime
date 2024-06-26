using Backend_MusicTime.Enterprise.Domain.Model.Commands;
using Backend_MusicTime.Enterprise.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Enterprise.Domain.Model.Aggregates;

public partial class Enterprise
{
    public int Id { get; }
    
    public EnterpriseName Name { get; private set; }
    public EnterpriseEmailAddress Email { get; private set; }
    public EnterpriseAddress Address { get; private set; }
    
    public string EnterpriseName => Name.Name;
    public string EmailAddress => Email.Address;
    public string EnterpriseAddress => Address.FullAddress;
    
    public Enterprise()
    {
        Name = new EnterpriseName();
        Email = new EnterpriseEmailAddress();
        Address = new EnterpriseAddress();
    }
    
    public Enterprise(string name, string email, string street, string number, string city, string postalCode, string country)
    {
        Name = new EnterpriseName(name);
        Email = new EnterpriseEmailAddress(email);
        Address = new EnterpriseAddress(street, number, city, postalCode, country);
    }
    
    public Enterprise(CreateEnterpriseCommand command)
    {
        Name = new EnterpriseName(command.Name);
        Email = new EnterpriseEmailAddress(command.Email);
        Address = new EnterpriseAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);
    }
}