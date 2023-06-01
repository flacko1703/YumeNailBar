using AutoMapper;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Application.Common.Mappings;

public class ProcedureMappingProfile : Profile
{
    public ProcedureMappingProfile()
    {
        CreateMap<Procedure, ProcedureDto>()
            .ForMember(dto => dto.ProcedureKind, opt 
                => opt.MapFrom(p => p.ProcedureKind))
            .ForMember(dto => dto.Price, opt 
                => opt.MapFrom(p => p.Price));
        CreateMap<ProcedureDto, Procedure>()
            .ForMember(proc => proc.ProcedureKind, opt 
                => opt.MapFrom(dto => dto.ProcedureKind))
            .ForMember(proc => proc.Price, opt 
                => opt.MapFrom(dto => dto.Price));

        CreateMap<List<Procedure>, List<ProcedureDto>>().ReverseMap();
    }
}