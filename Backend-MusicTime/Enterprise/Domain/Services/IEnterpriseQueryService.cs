using Backend_MusicTime.Enterprise.Domain.Model.Queries;

namespace Backend_MusicTime.Enterprise.Domain.Services;

public interface IEnterpriseQueryService
{
    Task<IEnumerable<Model.Aggregates.Enterprise>> Handle(GetAllEnterprisesQuery query);
    
    Task<Model.Aggregates.Enterprise?> Handle(GetEnterpriseByIdQuery query);
    
    Task<Model.Aggregates.Enterprise?> Handle(GetEnterpriseByEmailQuery query);
}