namespace Backend_MusicTime.Contracts.Domain.Model.Commands;

public record CreateContractCommand(
    string CustomerFirstName,
    string CustomerLastName,
    string MusicianFirstName,
    string MusicianLastName,
    string Reason,
    DateTime EventDate, 
    string Street, 
    string Number, 
    string City);