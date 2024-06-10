using Backend_MusicTime.Review.Domain.Model.Queries;
using Backend_MusicTime.Review.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Backend_MusicTime.Review.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PuntuationsController(
    IPuntuationCommandService puntuationCommandService,
    IPuntuationQueryService puntuationQueryService
    ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPuntuations()
    {
        var getAllPuntuationsQuery = new GetAllPuntuationsQuery();
        var puntuations = await puntuationQueryService.Handle(getAllPuntuationsQuery);
        return Ok(puntuations);
    }
}
