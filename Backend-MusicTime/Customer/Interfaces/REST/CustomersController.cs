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
    [HttpGet("{customerId:int}")]
    public async Task<IActionResult> GetCustomerById(int customerId)
    {
        var getCustomerByIdQuery = new GetCustomerByIdQuery(customerId);
        var customer = await customerQueryService.Handle(getCustomerByIdQuery);
        if (customer == null) return NotFound();
        var customerResource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
        return Ok(customerResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerResource resource)
    {
        var createCustomerCommand = CreateCustomerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var customer = await customerCommandService.Handle(createCustomerCommand);
        if (customer is null) return BadRequest();
        var customerResource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
        return CreatedAtAction(nameof(GetCustomerById), new {customerId = customerResource.Id}, customerResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var getAllCustomersQuery = new GetAllCustomersQuery();
        var customers = await customerQueryService.Handle(getAllCustomersQuery);
        var customerResources = customers.Select(CustomerResourceFromEntityAssembler.ToResourceFromEntity);   
        return Ok(customerResources);
    }

    [HttpPut("{customerId:int}")]
    public async Task<IActionResult> UpdateCustomer(int customerId, UpdateCustomerResource resource)
    {
        var updateCustomerCommand =
            UpdateCustomerCommandFromResourceAssembler.ToCommandFromResource(resource, customerId);
        var result = await customerCommandService.Handle(updateCustomerCommand);
        if (result == null)
        {
            return NotFound($"Customer with id {customerId} not found");
        }

        return NoContent();
    }
}