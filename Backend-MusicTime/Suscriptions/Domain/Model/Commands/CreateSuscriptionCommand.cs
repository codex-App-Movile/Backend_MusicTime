namespace Backend_MusicTime.Suscriptions.Domain.Model.Commands;

public record CreateSuscriptionCommand(int Id, string Name, string Message, string Features, string Image, int Price);