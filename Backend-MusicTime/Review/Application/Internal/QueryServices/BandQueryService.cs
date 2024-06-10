using Backend_MusicTime.Review.Domain.Model.Aggregates;
using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Model.Queries;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Review.Domain.Services;

namespace Backend_MusicTime.Review.Application.Internal.QueryServices;

public class BandQueryService(IBandRepository bandRepository) : IBandQueryService
{
    public async Task<IEnumerable<Band>> Handle(GetAllBandsQuery query) => await bandRepository.ListAsync();

    public async Task<Band?> Handle(GetBandByIdQuery query) => await bandRepository.FindByIdAsync(query.BandId.Value);

    public async Task<IEnumerable<Comment>> Handle(GetAllCommentsByBandIdQuery query) => await bandRepository.GetCommentsByBandId(query.BandId.Value);

    public async Task<IEnumerable<Puntuation>> Handle(GetAllPuntuationsByBandIdQuery query) => await bandRepository.GetPuntuationsByBandId(query.BandId.Value);
}
