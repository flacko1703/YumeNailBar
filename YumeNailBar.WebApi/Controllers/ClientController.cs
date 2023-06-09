using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using YumeNailBar.Application.Common.Mappings.ManualMappings;
using YumeNailBar.Application.Customers.Commands.CreateCustomerCommand;
using YumeNailBar.Application.Customers.Queries.GetAllCustomers;
using YumeNailBar.Application.Customers.Queries.GetCustomerById;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id}")]
    public async Task<CustomerDto> Get(Guid Id)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery(Id));
        return result;
    }
    
    [HttpGet]
    public async Task<Results<Ok<IEnumerable<Customer>>, NotFound<IEnumerable<Customer>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllCustomersQuery());
        return TypedResults.Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerDto customerDto)
    {
        var result = await _mediator
            .Send(new CreateCustomerCommand(customerDto.Registrations.MapCollectionToModels(), customerDto.Name,
                customerDto.PhoneNumber, customerDto.Email, customerDto.Comment));
        
        //var json = JsonSerializer.Serialize<Result<Customer>>(result);
        
        return Ok();
    }
    
    
    
    
}