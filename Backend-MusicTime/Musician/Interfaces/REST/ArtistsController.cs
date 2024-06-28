using System.Net.Mime;
using Backend_MusicTime.Musician.Domain.Model.Commands;
using Backend_MusicTime.Musician.Domain.Model.Queries;
using Backend_MusicTime.Musician.Domain.Services;
using Backend_MusicTime.Musician.Interfaces.REST.Resources;
using Backend_MusicTime.Musician.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_MusicTime.Musician.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistCommandService _artistCommandService;
        private readonly IArtistQueryService _artistQueryService;

        public ArtistsController(IArtistCommandService artistCommandService, IArtistQueryService artistQueryService)
        {
            _artistCommandService = artistCommandService;
            _artistQueryService = artistQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createArtistCommand = CreateArtistCommandFromResourceAssembler.ToCommandFromResource(resource);
            var artist = await _artistCommandService.Handle(createArtistCommand);
            if (artist is null) return BadRequest("Unable to create artist");

            var artistResource = ArtistResourceFromEntityAssembler.ToResourceFromEntity(artist);
            return CreatedAtAction(nameof(GetArtistById), new { artistId = artistResource.Id }, artistResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var getAllArtistsQuery = new GetAllMusicianQuery();
            var artists = await _artistQueryService.Handle(getAllArtistsQuery);
            if (artists == null || !artists.Any()) return NotFound("No artists found");

            var artistResources = artists.Select(ArtistResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(artistResources);
        }

        [HttpGet("{artistId:int}")]
        public async Task<IActionResult> GetArtistById(int artistId)
        {
            var getArtistByIdQuery = new GetMusicianByIdQuery(artistId);
            var artist = await _artistQueryService.Handle(getArtistByIdQuery);
            if (artist == null) return NotFound($"Artist with ID {artistId} not found");

            var artistResource = ArtistResourceFromEntityAssembler.ToResourceFromEntity(artist);
            return Ok(artistResource);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateArtist(int id, [FromBody] UpdateArtistResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateArtistCommand = UpdateArtistCommandFromResourceAssembler.ToCommandFromResource(resource, id);
            var result = await _artistCommandService.Handle(updateArtistCommand);

            if (result == null)
            {
                return NotFound($"Artist with ID {id} not found");
            }

            var updatedArtistResource = ArtistResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(updatedArtistResource);
        }
    }
}