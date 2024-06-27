using Backend_MusicTime.Enterprise.Domain.Model.Queries;
using Backend_MusicTime.Enterprise.Domain.Repositories;
using Backend_MusicTime.Enterprise.Domain.Services;

namespace Backend_MusicTime.Enterprise.Application.Internal.QueryServices;

public class EnterpriseQueryService(IEnterpriseRepository enterpriseRepository) : IEnterpriseQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Enterprise>> Handle(GetAllEnterprisesQuery query)
    {
        return await enterpriseRepository.ListAsync();
    }
    
    public async Task<Domain.Model.Aggregates.Enterprise?> Handle(GetEnterpriseByEmailQuery query)
    {
        return await enterpriseRepository.FindEnterpriseByEmailAsync(query.Email);
    }
    
    public async Task<Domain.Model.Aggregates.Enterprise?> Handle(GetEnterpriseByIdQuery query)
    {
        return await enterpriseRepository.FindByIdAsync(query.EnterpriseId);
    }
}