using System.Linq;
using AutoMapper;
using ShinyBooking.Dto;
using ShinyBooking.Models;

namespace ShinyBooking.Helpers.Automapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Room, RoomForReturnDetailsDto>()
                .ForMember(dto => dto.Equipments, opt =>
                    opt.MapFrom(r => r.RoomEquipments.Select(re => re.Equipment).ToList()))
                .ForMember(dto => dto.AmenitiesForDisabled, opt =>
                    opt.MapFrom(r => r.RoomAmenitiesForDisabled.Select(ra => ra.AmenitiesForDisabled).ToList()))
                .ForMember(dto => dto.Activities, opt =>
                    opt.MapFrom(r => r.RoomActivities.Select(ra => ra.Activities).ToList()));
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<Equipment, EquipmentForReturnDto>();
            CreateMap<AmenitiesForDisabled, AmenitiesForDisabledDto>();
            CreateMap<Activities, ActivitiesForReturnDto>();
            CreateMap<RoomAddress, RoomAddressForReturnDto>();
        }
    }
}