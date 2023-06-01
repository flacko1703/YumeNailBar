using AutoMapper;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.Common.Mappings;

public class RegistrationMappingProfile : Profile
{
    public RegistrationMappingProfile()
    {
        CreateMap<Registration, RegistrationDto>()
            .ForMember(dto => dto.Procedures, opt
                => opt.MapFrom(p => p.Procedures))
            .ForMember(dto => dto.AppointmentDate, opt
                => opt.MapFrom(p => p.GetAppointmentDate()))
            .ForMember(dto => dto.IsCanceled, opt
                => opt.MapFrom(p => p.GetStatus()));

        CreateMap<RegistrationDto, Registration>()
            .ForMember(dto => dto.Procedures, opt
                => opt.MapFrom(p => p.Procedures))
            .ForPath(dto => dto.GetStatus(), opt
                => opt.MapFrom(p => p.IsCanceled))
            .ForMember(dto => dto.GetAppointmentDate(), opt
                => opt.MapFrom(p => p.AppointmentDate));

        CreateMap<List<Registration>, List<RegistrationDto>>().ReverseMap();

    }
}