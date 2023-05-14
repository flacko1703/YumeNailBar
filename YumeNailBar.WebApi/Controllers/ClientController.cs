using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

    public ClientController(IClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpGet]
    public IActionResult Get()
    {
        Client client = _clientFactory.Create("TEST", "987987987987");

        ClientWriteModel writeModel = new("TEST", "987987987987", null, "false");
        var json = JsonSerializer.Serialize(writeModel);
        return Ok(json);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClientWriteModel client)
    {
        ClientWriteModel writeModel = new("TEST", "987987987987", null, "false");
        var json = JsonSerializer.Serialize(writeModel);
        return Ok(json);
    }
    
    
    
    
}