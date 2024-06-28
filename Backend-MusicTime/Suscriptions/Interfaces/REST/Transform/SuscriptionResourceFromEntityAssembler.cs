using Backend_MusicTime.Suscriptions.Domain.Model.Aggregates;
using Backend_MusicTime.Suscriptions.Interfaces.REST.Resources;

namespace Backend_MusicTime.Suscriptions.Interfaces.REST.Transform;

public static class SuscriptionResourceFromEntityAssembler
{
    public static SuscriptionResource ToResourceFromEntity(Suscription entity)
    {
        return new SuscriptionResource(entity.Id, entity.Name, entity.Message, entity.Features, entity.Image, entity.PricePerMonth);
    }
}