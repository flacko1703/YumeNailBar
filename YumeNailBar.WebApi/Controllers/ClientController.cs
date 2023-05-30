using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YumeNailBar.Application.Customers.Commands.CreateCustomerCommand;
using YumeNailBar.Application.Customers.Queries.GetAllCustomers;
using YumeNailBar.Application.Customers.Queries.GetCustomerById;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ClientController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{Id}")]
    public async Task<CustomerDto> Get(Guid Id)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery(Id));
        return result;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerDto customerDto)
    {
        var result = await _mediator
            .Send(new CreateCustomerCommand(customerDto.Registration, customerDto.Name,
                customerDto.PhoneNumber, customerDto.Email, customerDto.Comment));
        
        //var json = JsonSerializer.Serialize<Result<Customer>>(result);
        
        return Ok();
    }
    
    
    
    
}