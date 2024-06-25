
namespace Backend_MusicTime.Contracts.Interfaces.REST.Resources;

public record ContractResource(int Id, string CustomerFullName, string MusicianFullName, DateTime EventDate, string EventLocation, string Reason);