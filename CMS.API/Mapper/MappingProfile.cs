using AutoMapper;
using CMS.API.DTOs;
using CMS.API.Entities;

namespace CMS.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationSettingsDTO, ApplicationSettings>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<EventDTO, Event>();
            CreateMap<PartnerDTO, Partner>();
            CreateMap<SpeakerDTO, Speaker>();
            CreateMap<SponsorDTO, Sponsor>();
            CreateMap<PaymentDTO, Payement>();
            CreateMap<PlannerDTO, Planner>();
            CreateMap<PlannerSpeakerDTO, PlannerSpeaker>();
            CreateMap<EventAttendanceDTO, EventAttendance>();
            CreateMap<EventCategoryDTO, EventCategory>();
            CreateMap<PartnerEventDTO, PartnerEvent>();
            CreateMap<SponsorEventDTO, SponsorEvent>();


            CreateMap<ApplicationSettings, ApplicationSettingsDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Event, EventDTO>();
            CreateMap<Partner, PartnerDTO>();
            CreateMap<Speaker, SpeakerDTO>();
            CreateMap<Sponsor, SponsorDTO>();
            CreateMap<Payement, PaymentDTO>();
            CreateMap<Planner, PlannerDTO>();
            CreateMap<PlannerSpeaker,  PlannerSpeakerDTO>();
            CreateMap<EventAttendance, EventAttendanceDTO>();
            CreateMap<EventCategory, EventCategoryDTO>();
            CreateMap<PartnerEvent, PartnerEventDTO>();
            CreateMap<SponsorEvent, SponsorEventDTO>();

        }
    }
}
