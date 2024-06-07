namespace Backend_MusicTime.Contracts.Domain.Model.Commands;

public record CreateContractCommand(
    int Id,
    string CustomerFirstName, 
    string CustomerLastName, 
    string MusicianFirstName, 
    string MusicianLastName, 
    DateTime EventDate, 
    string Street, 
    string Number, 
    string City, 
    string Terms
);