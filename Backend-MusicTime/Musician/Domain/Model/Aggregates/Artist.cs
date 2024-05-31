using Backend_MusicTime.Musician.Domain.Model.Commands;
using Backend_MusicTime.Musician.Domain.Model.ValueObjects;
namespace Backend_MusicTime.Musician.Domain.Model.Aggregates;

public partial class Artist
{
    public int Id { get; }
    public MusicianName Name { get; private set; }
    public string Description { get; private set; }
    public string Image { get; private set; }
    public string GroupMusician { get; private set; }
    
    public string FullName => Name.FullName;
    
    public Artist(int id)
    {
        Id = id;
        Name = new MusicianName();
        Description = string.Empty;
        Image = string.Empty;
        GroupMusician = string.Empty;
    }
    public Artist(string fistName, string lastName, string description, string image, string groupMusician, int id)
    {
        Name = new MusicianName(fistName, lastName);
        Description = description;
        Image = image;
        GroupMusician = groupMusician;
        Id = id;
    }
    public Artist(CreateMusicianCommand command, int id)
    {
        Id = id;
        Name = new MusicianName(command.FirstName, command.LastName);
        Description = command.Description;
        Image = command.Image;
        GroupMusician = command.GroupMusician;
    }
    
}