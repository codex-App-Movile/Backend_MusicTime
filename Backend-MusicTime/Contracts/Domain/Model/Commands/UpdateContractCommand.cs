namespace Backend_MusicTime.Contracts.Domain.Model.Commands
{
    public record UpdateContractCommand(
        int Id,
        DateTime EventDate, 
        string Street, 
        string Number, 
        string City);
}