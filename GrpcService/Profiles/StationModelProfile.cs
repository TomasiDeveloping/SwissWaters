using AutoMapper;
using Core.DataTransferObjects;
using Google.Protobuf.WellKnownTypes;
using GrpcService.Protos;

namespace GrpcService.Profiles
{
    public class StationModelProfile : Profile
    {
        public StationModelProfile()
        {
            CreateMap<StationDto, StationsModel>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<StationAbilityDto, StationAbilityModel>()
                .ForMember(des => des.StationId, opt => opt.MapFrom(src => src.StationId.ToString()))
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<MeasurementDto, MeasurementModel>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(des => des.StationAbilityId, opt => opt.MapFrom(src => src.StationAbilityId.ToString()))
                .ForMember(des => des.Value, opt => opt.MapFrom(src => (double) src.Value))
                .ForMember(des => des.Max24H, opt => opt.MapFrom(src => (double) src.Max24H))
                .ForMember(des => des.Min24H, opt => opt.MapFrom(src => (double)src.Min24H))
                .ForMember(des => des.Mean24H, opt => opt.MapFrom(src => (double) src.Mean24H))
                .ForMember(des => des.MeasurementTime,
                    opt => opt.MapFrom(src =>
                        Timestamp.FromDateTime(DateTime.SpecifyKind(src.MeasurementTime, DateTimeKind.Utc))));
        }
    }
}
