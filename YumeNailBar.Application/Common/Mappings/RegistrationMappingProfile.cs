using AutoMapper;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.Common.Mappings;

public class RegistrationMappingProfile : Profile
{
    public RegistrationMappingProfile()
    {
        CreateMap<Registration, RegistrationDto>().ReverseMap();

    }
}