namespace Backend_MusicTime.Musician.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}