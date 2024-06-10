using Backend_MusicTime.Review.Domain.Model.Queries;
using Backend_MusicTime.Review.Domain.Model.ValueObjects;
using Backend_MusicTime.Review.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Backend_MusicTime.Review.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BandsController(
    IBandCommandService bandCommandService,
    IBandQueryService bandQueryService)
    :ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllBands()
    {
        var getAllBandsQuery = new GetAllBandsQuery();
        var bands = await bandQueryService.Handle(getAllBandsQuery);
        return Ok(bands);
    }
    [HttpGet("{bandId:int}")]
    public async Task<IActionResult> GetBandById(int bandId)
    {
        var getBandByIdQuery = new GetBandByIdQuery(new BandId(bandId));
        var band = await bandQueryService.Handle(getBandByIdQuery);
        if (band is null) return NotFound();
        return Ok(band);
    }
    [HttpGet("{bandId:int}/comments")]
    public async Task<IActionResult> GetCommentsByBandId(int bandId)
    {
        var getCommentsByBandIdQuery = new GetAllCommentsByBandIdQuery(new BandId(bandId));
        var comments = await bandQueryService.Handle(getCommentsByBandIdQuery);
        return Ok(comments);
    }

    [HttpGet("{bandId:int}/puntuations")]
    public async Task<IActionResult> GetPuntuationsByBandId(int bandId)
    {
        var getPuntuationsByBandIdQuery = new GetAllPuntuationsByBandIdQuery(new BandId(bandId));
        var puntuations = await bandQueryService.Handle(getPuntuationsByBandIdQuery);
        return Ok(puntuations);
    }
}
