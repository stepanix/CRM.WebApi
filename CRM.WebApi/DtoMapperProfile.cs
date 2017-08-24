using AutoMapper;
using CRM.Domain.Model;
using CRM.WebApi.Dto.FormValues.In;
using CRM.WebApi.Dto.Notes.In;

namespace CRM.WebApi
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<FormValueModel, FormValueDtoIn>().ReverseMap();
            CreateMap<NoteModel, NoteDtoIn>().ReverseMap();
        }
    }
}