using Backend_MusicTime.Suscriptions.Domain.Model.Commands;
using Backend_MusicTime.Suscriptions.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Suscriptions.Domain.Model.Aggregates;

public class Suscription
{
    public int Id { get; }
    public string Name { get; set; }    
    public string Message { get; set; }
    public string Features { get; set; }
    public string Image { get; set; }
    public SuscriptionPrice Price { get; set; }

    public int PricePerMonth => Price.PricePerMonth;
    
    public Suscription()
    {
        Name = string.Empty;
        Message = string.Empty;
        Features = string.Empty;
        Image = string.Empty;
        Price = new SuscriptionPrice();
    }
    
    public Suscription(string name, string message, string features, string image, int price)
    {
        Name = name;
        Message = message;
        Features = features;
        Image = image;
        Price = new SuscriptionPrice(price);
    }
    
    public Suscription(CreateSuscriptionCommand command)
    {
        Name = command.Name;
        Message = command.Message;
        Features = command.Features;
        Image = command.Image;
        Price = new SuscriptionPrice(command.Price);
    }
}