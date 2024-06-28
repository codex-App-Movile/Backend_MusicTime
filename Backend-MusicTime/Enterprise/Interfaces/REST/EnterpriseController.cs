using System.Net.Mime;
using Backend_MusicTime.Enterprise.Domain.Model.Queries;
using Backend_MusicTime.Enterprise.Domain.Services;
using Backend_MusicTime.Enterprise.Interfaces.REST.Resources;
using Backend_MusicTime.Enterprise.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MusicTime.Enterprise.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class EnterprisesController(IEnterpriseCommandService enterpriseCommandService, IEnterpriseQueryService enterpriseQueryService) 
    : ControllerBase
{
    [HttpGet("{enterpriseId:int}")]
    
    public async Task<IActionResult> GetEnterpriseById(int enterpriseId)
    {
        var getEnterpriseByIdQuery = new GetEnterpriseByIdQuery(enterpriseId);
        var enterprise = await enterpriseQueryService.Handle(getEnterpriseByIdQuery);
        if (enterprise == null) return NotFound();
        var enterpriseResource = EnterpriseResourceFromEntityAssembler.ToResourceFromEntity(enterprise);
        return Ok(enterpriseResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEnterprise(CreateEnterpriseResource resource)
    {
        var createEnterpriseCommand = CreateEnterpriseCommandFromResourceAssembler.ToCommandFromResource(resource);
        var enterprise = await enterpriseCommandService.Handle(createEnterpriseCommand);
        if (enterprise is null) return BadRequest();
        var enterpriseResource = EnterpriseResourceFromEntityAssembler.ToResourceFromEntity(enterprise);
        return CreatedAtAction(nameof(GetEnterpriseById), new {enterpriseId = enterpriseResource.Id}, enterpriseResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllEnterprises()
    {
        var getAllEnterprisesQuery = new GetAllEnterprisesQuery();
        var enterprises = await enterpriseQueryService.Handle(getAllEnterprisesQuery);
        var enterpriseResources = enterprises.Select(EnterpriseResourceFromEntityAssembler.ToResourceFromEntity);   
        return Ok(enterpriseResources);
    }
}