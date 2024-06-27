namespace Backend_MusicTime.Enterprise.Interfaces.ACL;

public interface IEnterpriseContextFacade
{
    Task<int> CreateEnterprise(string name, string email, string street, string number, string city, string postalCode, string country);
    
    Task<int> FetchEnterpriseIdByEmail(string email);
}