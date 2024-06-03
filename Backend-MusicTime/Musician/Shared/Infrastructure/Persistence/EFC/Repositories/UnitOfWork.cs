using Backend_MusicTime.Musician.Shared.Domain.Repositories;
using Backend_MusicTime.Musician.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Backend_MusicTime.Musician.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}