using Backend_MusicTime.Contracts.Domain.Model.Commands;
using Backend_MusicTime.Contracts.Interfaces.REST.Resources;

namespace Backend_MusicTime.Contracts.Interfaces.REST.Transform;

public class UpdateContractCommandFromResourceAssembler
{
    public static UpdateContractCommand ToCommandFromResource(UpdateContractResource resource, int contractId)
    {
        return new UpdateContractCommand(
            Id: contractId,
            EventDate: resource.EventDate,
            Street: resource.Street,
            Number: resource.Number,
            City: resource.City

        );
    }
}