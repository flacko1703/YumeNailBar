using System.Text.Json;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YumeNailBar.Application.DTO;
using YumeNailBar.Application.Registration.Commands.CreateClientCommand;
using YumeNailBar.Application.Registration.Queries.GetRegistrationById;
using YumeNailBar.Domain.Factories;

namespace YumeNailBar.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientFactory _clientFactory;
    private readonly IMediator _mediator;

    public ClientController(IClientFactory clientFactory, IMediator mediator)
    {
        _clientFactory = clientFactory;
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
        var json = JsonSerializer.Serialize(registration);
        return Ok(json);
    }
    
    
    
    
}