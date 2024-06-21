using System.Net.Mime;
using Backend_MusicTime.Customer.Domain.Model.Queries;
using Backend_MusicTime.Customer.Domain.Services;
using Backend_MusicTime.Customer.Interfaces.REST.Resources;
using Backend_MusicTime.Customer.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MusicTime.Customer.Interfaces.REST;

[ApiController] 
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)] 
public class CustomersController(ICustomerCommandService customerCommandService, ICustomerQueryService customerQueryService)
: ControllerBase
{
    [HttpGet("{clientId:int}")]
    public async Task<IActionResult> GetClientById(int clientId)
    {
        var getClientByIdQuery = new GetCustomerByIdQuery(clientId);
        var client = await customerQueryService.Handle(getClientByIdQuery);
        if (client == null) return NotFound();
        var clientResource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(client);
        return Ok(clientResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateClient(CreateCustomerResource resource)
    {
        var createClientCommand = CreateCustomerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var client = await customerCommandService.Handle(createClientCommand);
        if (client is null) return BadRequest();
        var clientResource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(client);
        return CreatedAtAction(nameof(GetClientById), new {clientId = clientResource.Id}, clientResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClients()
    {
        var getAllClientsQuery = new GetAllCustomersQuery();
        var clients = await customerQueryService.Handle(getAllClientsQuery);
        var clientResources = clients.Select(CustomerResourceFromEntityAssembler.ToResourceFromEntity);   
        return Ok(clientResources);
    }
}