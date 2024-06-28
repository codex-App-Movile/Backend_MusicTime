namespace Backend_MusicTime.Suscriptions.Interfaces.REST.Resources;

public record CreateSuscriptionResource(int Id, string Name, string Message, string Features, string Image, int Price);