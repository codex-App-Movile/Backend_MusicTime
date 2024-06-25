using System.Net.Mime;
using Backend_MusicTime.Contracts.Domain.Model.Commands;
using Backend_MusicTime.Contracts.Domain.Model.Queries;
using Backend_MusicTime.Contracts.Domain.Services;
using Backend_MusicTime.Contracts.Interfaces.REST.Resources;
using Backend_MusicTime.Contracts.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;


namespace Backend_MusicTime.Contracts.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ContractsController : ControllerBase
    {
        private readonly IContractCommandService _contractCommandService;
        private readonly IContractQueryService _contractQueryService;

        public ContractsController(IContractCommandService contractCommandService, IContractQueryService contractQueryService)
        {
            _contractCommandService = contractCommandService;
            _contractQueryService = contractQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract(CreateContractResource resource)
        {
            var createContractCommand = CreateContractCommandFromResourceAssembler.ToCommandFromResource(resource);
            var contract = await _contractCommandService.Handle(createContractCommand);
            if (contract is null) return BadRequest();
            var contractResource = ContractResourceFromEntityAssembler.ToResourceFromEntity(contract);
            return CreatedAtAction(nameof(GetContractById), new {contractId = contractResource.Id}, contractResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContracts()
        {
            var getAllContractsQuery = new GetContractsQuery();
            var contracts = await _contractQueryService.Handle(getAllContractsQuery);
            var contractResources = contracts.Select(ContractResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(contractResources);
        }

        [HttpGet("{contractId:int}")]
        public async Task<IActionResult> GetContractById(int contractId)
        {
            var getContractDetailsQuery = new GetContractDetailsQuery(contractId);
            var contract = await _contractQueryService.Handle(getContractDetailsQuery);
            if (contract == null) return NotFound();
            var contractResource = ContractResourceFromEntityAssembler.ToResourceFromEntity(contract);
            return Ok(contractResource);
        }
        
        [HttpPut("{contractId:int}")]
        public async Task<IActionResult> UpdateContract(int contractId, UpdateContractResource resource)
        {
            var updateContractCommand = UpdateContractCommandFromResourceAssembler.ToCommandFromResource(resource, contractId);

            var result = await _contractCommandService.Handle(updateContractCommand);

            if (result == null) return NotFound($"Contract with ID {contractId} not found.");

            return NoContent(); // O puedes devolver Ok() si prefieres confirmar la actualización con una respuesta.
        }
        
        [HttpDelete("{contractId:int}")]
        public async Task<IActionResult> DeleteContract(int contractId)
        {
            var deleteCommand = new DeleteContractCommand(contractId);
            var result = await _contractCommandService.DeleteContractByIdAsync(deleteCommand);

            if (!result) return NotFound($"Contract with ID {contractId} not found.");

            return NoContent();
        }

        
    }
}