using Backend_MusicTime.Contracts.Domain.Model.Commands;
using Backend_MusicTime.Contracts.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Contracts.Domain.Model.Aggregates;

public partial class Contract
{
    public Contract(int id)
    {
        Id = id;
        CustomerName = new PersonName();
        MusicianName = new PersonName();
        EventLocation = new StreetAddress();
        Terms = string.Empty;
        EventDate = DateTime.MinValue;
    }

    public Contract(string customerFirstName, string customerLastName, string musicianFirstName, string musicianLastName, DateTime eventDate, string street, string number, string city, string terms, int id, PersonName customerName, PersonName musicianName)
    {
        CustomerName = new PersonName(customerFirstName, customerLastName);
        MusicianName = new PersonName(musicianFirstName, musicianLastName);
        EventDate = eventDate;
        EventLocation = new StreetAddress(street, number, city);
        Terms = terms;
        Id = id;
    }

    public Contract(CreateContractCommand command, int id, PersonName customerName, PersonName musicianName, string terms)
    {
        Id = id;
        CustomerName = new PersonName(command.CustomerFirstName, command.CustomerLastName);
        MusicianName = new PersonName(command.MusicianFirstName, command.MusicianLastName);
        EventDate = command.EventDate;
        EventLocation = new StreetAddress(command.Street, command.Number, command.City);
        Terms = command.Terms;
    }
    
    public Contract(CreateContractCommand command, PersonName customerName, PersonName musicianName, string terms)
    {
        CustomerName = customerName;
        MusicianName = musicianName;
        Terms = terms;
        EventDate = command.EventDate;
        EventLocation = new StreetAddress(command.Street, command.Number, command.City);
    }

    
    public int Id { get; set; } 
    public PersonName CustomerName { get; set; }
    public PersonName MusicianName { get; set; }
    public DateTime EventDate { get; set; }
    public StreetAddress EventLocation { get; set; }
    public string Terms { get; private set; }

    public string FullCustomerName => CustomerName.FullName;
    public string FullMusicianName => MusicianName.FullName;
    public string StreetAddress  => EventLocation.FullAddress;
    public Guid MusicianId { get; set; }
}