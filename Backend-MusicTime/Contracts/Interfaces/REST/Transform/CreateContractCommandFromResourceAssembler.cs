using Backend_MusicTime.Contracts.Domain.Model.Commands;
using Backend_MusicTime.Contracts.Interfaces.REST.Resources;

namespace Backend_MusicTime.Contracts.Interfaces.REST.Transform;

public class CreateContractCommandFromResourceAssembler
{
    public static CreateContractCommand ToCommandFromResource(CreateContractResource resource)
    {
        return new CreateContractCommand(
            resource.CustomerFirstName, 
            resource.CustomerLastName, 
            resource.MusicianFirstName, 
            resource.MusicianLastName, 
            resource.Reason, 
            resource.EventDate, 
            resource.EventLocationStreet, 
            resource.EventLocationNumber, 
            resource.EventLocationCity);
    }
}