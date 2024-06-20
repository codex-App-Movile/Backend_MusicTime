using Backend_MusicTime.Client.Domain.Model.Queries;

namespace Backend_MusicTime.Client.Domain.Services;

public interface IClientQueryService
{
    Task<IEnumerable<Model.Aggregates.Client>> Handle(GetAllClientsQuery query);
    Task<Model.Aggregates.Client?> Handle(GetClientByEmailQuery query);
    Task<Model.Aggregates.Client?> Handle(GetClientByIdQuery query);
}