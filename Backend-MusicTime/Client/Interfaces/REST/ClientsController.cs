using System.Net.Mime;
using Backend_MusicTime.Client.Domain.Model.Queries;
using Backend_MusicTime.Client.Domain.Services;
using Backend_MusicTime.Client.Interfaces.REST.Resources;
using Backend_MusicTime.Client.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MusicTime.Client.Interfaces.REST;

[ApiController] 
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)] 
public class ClientsController(IClientCommandService clientCommandService, IClientQueryService clientQueryService)
: ControllerBase
{
    [HttpGet("{clientId:int}")]
    public async Task<IActionResult> GetClientById(int clientId)
    {
        var getClientByIdQuery = new GetClientByIdQuery(clientId);
        var client = await clientQueryService.Handle(getClientByIdQuery);
        if (client == null) return NotFound();
        var clientResource = ClientResourceFromEntityAssembler.ToResourceFromEntity(client);
        return Ok(clientResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateClient(CreateClientResource resource)
    {
        var createClientCommand = CreateClientCommandFromResourceAssembler.ToCommandFromResource(resource);
        var client = await clientCommandService.Handle(createClientCommand);
        if (client is null) return BadRequest();
        var clientResource = ClientResourceFromEntityAssembler.ToResourceFromEntity(client);
        return CreatedAtAction(nameof(GetClientById), new {clientId = clientResource.Id}, clientResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClients()
    {
        var getAllClientsQuery = new GetAllClientsQuery();
        var clients = await clientQueryService.Handle(getAllClientsQuery);
        var clientResources = clients.Select(ClientResourceFromEntityAssembler.ToResourceFromEntity);   
        return Ok(clientResources);
    }
}