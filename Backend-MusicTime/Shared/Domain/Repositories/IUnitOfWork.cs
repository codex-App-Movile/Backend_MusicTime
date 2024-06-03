namespace Backend_MusicTime.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}