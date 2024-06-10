using Backend_MusicTime.Review.Domain.Model.Aggregates;
using Backend_MusicTime.Review.Domain.Model.Queries;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Review.Domain.Services;

namespace Backend_MusicTime.Review.Application.Internal.QueryServices;

public class BandQueryService(IBandRepository bandRepository) : IBandQueryService
{
    public Task<IEnumerable<Band>> Handle(GetAllBandsQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<Band?> Handle(GetBandByIdQuery query)
    {
        throw new NotImplementedException();
    }
}
