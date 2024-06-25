namespace Backend_MusicTime.Contracts.Interfaces.REST.Resources;

public record UpdateContractResource(
    DateTime EventDate,
    string Street,
    string Number,
    string City

);