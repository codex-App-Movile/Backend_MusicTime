using Backend_MusicTime.Enterprise.Domain.Model.Commands;
using Backend_MusicTime.Enterprise.Domain.Model.Queries;
using Backend_MusicTime.Enterprise.Domain.Model.ValueObjects;
using Backend_MusicTime.Enterprise.Domain.Services;

namespace Backend_MusicTime.Enterprise.Interfaces.ACL.Services;

public class EnterpriseContextFacade(IEnterpriseCommandService enterpriseCommandService,IEnterpriseQueryService enterpriseQueryService) : IEnterpriseContextFacade
{
    public async Task<int> CreateEnterprise(string name, string email, string street, string number, string city, string postalCode,
        string country)
    {
        var createEnterpriseCommand = new CreateEnterpriseCommand(name, email, street, number, city, postalCode, country);
        var enterprise = await enterpriseCommandService.Handle(createEnterpriseCommand);
        return enterprise?.Id ?? 0;
    }

    public async Task<int> FetchEnterpriseIdByEmail(string email)
    {
        var getEnterpriseByEmailQuery = new GetEnterpriseByEmailQuery(new EnterpriseEmailAddress(email));
        var enterprise = await enterpriseQueryService.Handle(getEnterpriseByEmailQuery);
        return enterprise?.Id ?? 0;
    }
}