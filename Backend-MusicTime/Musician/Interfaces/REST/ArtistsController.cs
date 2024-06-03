using System.Net.Mime;
using Backend_MusicTime.Musician.Domain.Model.Queries;
using Backend_MusicTime.Musician.Domain.Services;
using Backend_MusicTime.Musician.Interfaces.REST.Resources;
using Backend_MusicTime.Musician.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;


namespace Backend_MusicTime.Musician.Interfaces.REST;




[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class ArtistsController(IArtistCommandService artistCommandService, IArtistQueryService artistQueryService)
    : ControllerBase
{
    [HttpPost]
    
    public async Task<IActionResult> CreateArtist(CreateArtistResource resource)
    {
        var createArtistCommand = CreateArtistCommandFromResourceAssembler.ToCommandFromResource(resource);
        var artist = await artistCommandService.Handle(createArtistCommand);
        if (artist is null) return BadRequest();
        var artistResource = ArtistResourceFromEntityAssembler.ToResourceFromEntity(artist);
        return CreatedAtAction(nameof(GetArtistById), new {artistId = artistResource.Id}, artistResource);
    }
    
    [HttpGet]
    
    public async Task<IActionResult> GetAllArtists()
    {
        var getAllArtistsQuery = new GetAllMusicianQuery();
        var artists = await artistQueryService.Handle(getAllArtistsQuery);
        var artistResources = artists.Select(ArtistResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(artistResources);
    }
    
    [HttpGet("{artistId:int}")]

    public async Task<IActionResult> GetArtistById(int artistId)
    {
        var getArtistByIdQuery = new GetMusicianByIdQuery(artistId);
        var artist = await artistQueryService.Handle(getArtistByIdQuery);
        if (artist == null) return NotFound();
        var artistResource = ArtistResourceFromEntityAssembler.ToResourceFromEntity(artist);
        return Ok(artistResource);
    }
}