using Microsoft.AspNetCore.Components;
using YumeNailBar.Application.DTO;
using YumeNailBar.Blazor.Models;
using YumeNailBar.Blazor.Services;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Infrastructure.Persistence.EF.Models;

namespace YumeNailBar.Blazor.Pages;

public partial class Customer
{
    [Inject]
    private ICustomerService _customerService { get; set; }
    
    [Parameter]
    public Guid Id { get; set; }

    public CustomerViewModel CustomerModel { get; set; } = new();

    private async Task HandleValidInput()
    {
        if (Id == Guid.Empty)
        {
            var customerDto = CustomerViewModel.ToDto(CustomerModel);
            await _customerService.AddAsync(customerDto);
        }
        
        await Task.CompletedTask;
    }


    public void AddProcedure(ProcedureKind kind)
    {
        CustomerModel.Procedures.Add(new ProcedureDto(kind, 1000));
    }
}