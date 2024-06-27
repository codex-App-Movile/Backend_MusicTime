namespace Backend_MusicTime.Enterprise.Domain.Model.ValueObjects;

public record EnterpriseName(string Name)
{
    public EnterpriseName() : this(string.Empty)
    {
    }
    
};