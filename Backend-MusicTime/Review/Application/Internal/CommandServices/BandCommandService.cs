using Backend_MusicTime.Review.Domain.Model.Aggregates;
using Backend_MusicTime.Review.Domain.Model.Commands;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Review.Domain.Services;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Review.Application.Internal.CommandServices;

public class BandCommandService(IBandRepository bandRepository, IUnitOfWork uniUnitOfWork) : IBandCommandService
{
    public Task<Band?> Handle(CreateBandCommand command)
    {
        throw new NotImplementedException();
    }
}
