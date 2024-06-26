namespace Backend_MusicTime.Enterprise.Domain.Model.ValueObjects;

public record EnterpriseEmailAddress(string Address)
{
    public EnterpriseEmailAddress() : this(string.Empty)
    {
    }
    
};