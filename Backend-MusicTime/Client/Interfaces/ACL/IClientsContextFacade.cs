namespace Backend_MusicTime.Client.Interfaces.ACL;

public interface IClientsContextFacade
{
    Task<int> CreateClient(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country);
    
    Task<int> FetchClientIdByEmail(string email);
}