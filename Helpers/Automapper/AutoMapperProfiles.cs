using System.Linq;
using AutoMapper;
using ShinyBooking.Dto;
using ShinyBooking.Models;
using ShinyBooking.ViewModels;

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
                    opt.MapFrom(r => r.RoomActivities.Select(ra => ra.Activities).ToList()))
                .ForMember(dto => dto.CustomerInformation, opt =>
                    opt.MapFrom(r => r.Customer.Identity));

            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<Equipment, EquipmentForReturnDto>();
            CreateMap<AmenitiesForDisabled, AmenitiesForDisabledDto>();
            CreateMap<Activities, ActivitiesForReturnDto>();
            CreateMap<RoomAddress, RoomAddressForReturnDto>();
            CreateMap<RegistrationViewModel, ApplicationUser>();
            CreateMap<ApplicationUser, CustomerDetailsForRoomReturnDto>()
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(au => au.FirstName))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(au => au.LastName))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(au => au.Email))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(au => au.PhoneNumber));

            }
    }
}