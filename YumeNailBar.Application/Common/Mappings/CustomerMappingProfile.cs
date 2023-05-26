using AutoMapper;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.Common.Mappings;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(dto => dto.Registration, opt => opt.MapFrom(src => src.GetRegistration()))
            .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.GetName()))
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.GetPhoneNumber()))
            .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.GetEmail()))
            .ForMember(dto => dto.Comment, opt => opt.MapFrom(src => src.GetComment()));
        
        CreateMap<CustomerDto, Customer>()
            .ConstructUsing(dto => Customer.Create(
                Registration.Create(dto.Registration.Procedures
                            .Select(p 
                                => Procedure.Create(p.ProcedureKind, p.Price)).ToList(),
                    dto.Registration.AppointmentDate,
                    dto.Registration.IsCanceled), 
                dto.Name,
                dto.PhoneNumber, 
                dto.Email,
                dto.Comment));
    }
}