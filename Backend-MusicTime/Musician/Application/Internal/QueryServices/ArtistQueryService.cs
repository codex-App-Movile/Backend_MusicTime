using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Musician.Domain.Model.Queries;
using Backend_MusicTime.Musician.Domain.Repositories;
using Backend_MusicTime.Musician.Domain.Services;

namespace Backend_MusicTime.Musician.Application.Internal.QueryServices;

public class ArtistQueryService(IArtistRepository artistRepository) : IArtistQueryService
{
    public async Task<IEnumerable<Artist>> Handle(GetAllMusicianQuery query)
    {
        return await artistRepository.ListAsync();
    }
    
    public async Task<Artist?> Handle(GetMusicianByIdQuery query)
    {
        return await artistRepository.FindByIdAsync(query.MusicianId);
    }
    
    public async Task<Artist?> Handle(GetMusicianByGroupQuery query)
    {
        return await artistRepository.FindByGroupAsync(query.GroupMusician);
    }
}