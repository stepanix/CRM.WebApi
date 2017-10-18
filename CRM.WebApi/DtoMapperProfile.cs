using AutoMapper;
using CRM.Domain.Model;
using CRM.WebApi.Dto.Activities.In;
using CRM.WebApi.Dto.Form.In;
using CRM.WebApi.Dto.FormValues.In;
using CRM.WebApi.Dto.Notes.In;
using CRM.WebApi.Dto.Orders.In;
using CRM.WebApi.Dto.Photos.In;
using CRM.WebApi.Dto.Places.In;
using CRM.WebApi.Dto.ProductretailAudits.In;
using CRM.WebApi.Dto.Products.In;
using CRM.WebApi.Dto.RepresentativePlaces.In;
using CRM.WebApi.Dto.Schedules.In;
using CRM.WebApi.Dto.Statuses.In;
using CRM.WebApi.Dto.TimeMileages.In;
using CRM.WebApi.Dto.VisitLogs.In;

namespace CRM.WebApi
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<OrderModel, OrderDtoIn>().ReverseMap();
            CreateMap<ActivityModel, ActivityDtoIn>().ReverseMap();
            CreateMap<PhotoModel, PhotoDtoIn>().ReverseMap();
            CreateMap<TimeMileageModel, TimeMileageDtoIn>().ReverseMap();
            CreateMap<VisitLogModel, VisitLogDtoIn>().ReverseMap();
            CreateMap<StatusModel, StatusDtoIn>().ReverseMap();
            CreateMap<ProductModel, ProductDtoIn>().ReverseMap();
            CreateMap<PlaceModel, PlaceDtoIn>().ReverseMap();
            CreateMap<FormModel, FormDtoIn>().ReverseMap();
            CreateMap<FormValueModel, FormValueDtoIn>().ReverseMap();
            CreateMap<NoteModel, NoteDtoIn>().ReverseMap();
            CreateMap<ProductRetailAuditModel, ProductRetailAuditDtoIn>().ReverseMap();
            CreateMap<ScheduleModel, ScheduleDtoIn>().ReverseMap();
            CreateMap<RepresentativePlaceModel, RepresentativePlaceDtoIn>().ReverseMap();
        }
    }
}