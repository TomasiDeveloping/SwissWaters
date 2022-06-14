using AutoMapper;
using Core.DataTransferObjects;
using Database.Entities;

namespace Core.Profiles;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Station, StationDto>()
            .ForMember(des => des.CantonNames, opt => opt.MapFrom(src => src.CantonStations.Select(cs => cs.Canton.Name).ToList()))
            .ForMember(des => des.WatersTypeName, opt => opt.MapFrom(src => src.WatersType.Name));
        CreateMap<StationDto, Station>()
            .ForMember(des => des.WatersTypeId, opt => opt.MapFrom(src => new Guid(src.WatersTypeName)));

        CreateMap<Measurement, MeasurementDto>().ReverseMap();

        CreateMap<StationAbility, StationAbilityDto>().ReverseMap();

        CreateMap<Canton, CantonDto>();
    }
}