using System.Text.Json;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using YumeNailBar.Application.DTO;
using YumeNailBar.Application.RegistrationInfo.Commands.CreateClientCommand;
using YumeNailBar.Application.RegistrationInfo.Commands.CreateRegistrationCommand;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;
using YumeNailBar.Domain.Factories;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Domain.SeedWork.ValueObjects;

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
    public Task<Result> Get()
    {
        var result = _mediator.Send(new CreateClientCommand("TEST", "89999809351"));
        return result.ToResult().Value;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClientDto client)
    {
        ClientDto clientDto = new("TEST", "987987987987", null, "COMMENT");
        var json = JsonSerializer.Serialize(clientDto);
        return Ok(json);
    }
    
    
    
    
}