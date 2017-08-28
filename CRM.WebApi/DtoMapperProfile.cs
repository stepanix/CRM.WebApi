using AutoMapper;
using CRM.Domain.Model;
using CRM.WebApi.Dto.Form.In;
using CRM.WebApi.Dto.FormValues.In;
using CRM.WebApi.Dto.Notes.In;
using CRM.WebApi.Dto.ProductretailAudits.In;
using CRM.WebApi.Dto.Schedules.In;

namespace CRM.WebApi
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<FormModel, FormDtoIn>().ReverseMap();
            CreateMap<FormValueModel, FormValueDtoIn>().ReverseMap();
            CreateMap<NoteModel, NoteDtoIn>().ReverseMap();
            CreateMap<ProductRetailAuditModel, ProductRetailAuditDtoIn>().ReverseMap();
            CreateMap<ScheduleModel, ScheduleDtoIn>().ReverseMap();
        }
    }
}