using Backend_MusicTime.Enterprise.Domain.Model.Commands;

namespace Backend_MusicTime.Enterprise.Domain.Services;

public interface IEnterpriseCommandService
{
    Task<Model.Aggregates.Enterprise?> Handle(CreateEnterpriseCommand command); 
}