using Backend_MusicTime.Contracts.Domain.Model.Aggregates;
using Backend_MusicTime.Contracts.Interfaces.REST.Resources;

namespace Backend_MusicTime.Contracts.Interfaces.REST.Transform;

public static class ContractResourceFromEntityAssembler
{
    public static ContractResource ToResourceFromEntity(Contract entity)
    {
        return new ContractResource(
            entity.Id,
            entity.FullCustomerName,
            entity.FullMusicianName,
            entity.EventDate,
            entity.StreetAddress,
            entity.Reason); 
    }
}