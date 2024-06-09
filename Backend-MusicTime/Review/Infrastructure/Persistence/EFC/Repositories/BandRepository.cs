using Backend_MusicTime.Review.Domain.Model.Aggregates;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Backend_MusicTime.Review.Infrastructure.Persistence.EFC.Repositories;

public class BandRepository(AppDbContext context): BaseRepository<Band>(context), IBandRepository
{
}
