using MediatR;
using Microsoft.AspNetCore.Mvc;
using YumeNailBar.Application.DTO;
using YumeNailBar.Application.RegistrationUseCases.Commands.CreateRegistrationCommand;
using YumeNailBar.Application.RegistrationUseCases.Queries.GetRegistrationById;

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
    public async Task<IActionResult> Post([FromBody] RegistrationDto registration)
    {
        var json = await _mediator
            .Send(new CreateRegistrationCommand(registration.Id,
            registration.Customer,
            registration.AppointmentDate,
            registration.Procedures,
            registration.Comment,
            registration.IsCanceled));
        
        var result = CreatedAtAction(nameof(Get),
            new
            {
                id = registration.Id
            },
            null);
        return result;
    }
    
    
    
    
}