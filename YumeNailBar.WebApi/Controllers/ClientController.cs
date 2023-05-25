using MediatR;
using Microsoft.AspNetCore.Mvc;
using YumeNailBar.Application.DTO;
using YumeNailBar.Application.Registrations.Commands.CreateCustomerCommand;
using YumeNailBar.Application.Registrations.Queries.GetRegistrationById;
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

    [HttpGet]
    public async Task<IActionResult> Get(Guid Id)
    {
        var result = await _mediator.Send(new GetRegistrationByIdQuery(Id));
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerDto customer)
    {
        var procedures = customer.Registration.Procedures
            .Select(procedure => procedure.ToDomainModel()).ToList();

        var registration = Registration.Create(procedures, customer.Registration.AppointmentDate,
            customer.Registration.IsCanceled);

        var customerModel = await _mediator.Send(new CreateCustomerCommand(registration, customer.Name,
            customer.PhoneNumber, customer.Email, customer.Comment));

        var result = CreatedAtAction(nameof(Get), new { id = customer.Id }, null);
        return result;
    }
    
    
    
    
}