namespace Backend_MusicTime.Customer.Interfaces.ACL;

public interface ICustomersContextFacade
{
    Task<int> CreateClient(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country);
    
    Task<int> FetchClientIdByEmail(string email);
}