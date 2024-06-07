namespace Backend_MusicTime.Contracts.Interfaces.REST.Resources;

public record CreateContractResource(
    string CustomerFirstName, 
    string CustomerLastName, 
    string MusicianFirstName, 
    string MusicianLastName, 
    string Terms,
    DateTime EventDate,  
    string EventLocationStreet, 
    string EventLocationNumber, 
    string EventLocationCity);