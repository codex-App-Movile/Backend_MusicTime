namespace Backend_MusicTime.Suscriptions.Domain.Model.ValueObjects;

public record SuscriptionPrice(int Price)
{
    public SuscriptionPrice() : this(0)
    {
    }
    
    public int PricePerMonth => Price;
}