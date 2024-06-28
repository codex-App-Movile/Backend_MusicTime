using System.Net.Mime;
using Backend_MusicTime.Suscriptions.Domain.Model.Queries;
using Backend_MusicTime.Suscriptions.Domain.Services;
using Backend_MusicTime.Suscriptions.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MusicTime.Suscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)] 
public class SuscriptionsController(ISuscriptionQueryService suscriptionQueryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllSuscriptions()
    {
        var getAllSuscriptionsQuery = new GetAllSuscriptionsQuery();    
        var suscriptions = await suscriptionQueryService.Handle(getAllSuscriptionsQuery);
        var suscriptionResources = suscriptions.Select(SuscriptionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(suscriptionResources);
    }
}