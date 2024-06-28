using Backend_MusicTime.Suscriptions.Domain.Model.Aggregates;
using Backend_MusicTime.Suscriptions.Domain.Model.Queries;

namespace Backend_MusicTime.Suscriptions.Domain.Services;

public interface ISuscriptionQueryService
{
    Task<IEnumerable<Suscription>> Handle(GetAllSuscriptionsQuery query);
}