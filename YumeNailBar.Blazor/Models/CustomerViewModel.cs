using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Blazor.Models;

public class CustomerViewModel
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }
    public ProcedureKind ProcedureKind { get; set; }
    public List<ProcedureDto> Procedures { get; set; } = new List<ProcedureDto>()
    {
        new ProcedureDto(ProcedureKind.Manicure, 11111)
    };


    public static CustomerDto ToDto(CustomerViewModel model)
    {
        return new CustomerDto(new RegistrationDto(model.Date, model.Procedures, false), model.Name, 
            model.PhoneNumber,
            model.Email, model.Comment);
    }
}