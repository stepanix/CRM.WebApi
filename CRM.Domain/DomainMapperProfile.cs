﻿using AutoMapper;
using CRM.Domain.Entities;
using CRM.Domain.Model;

namespace CRM.Domain
{
    public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Form, FormModel>().ReverseMap();
            CreateMap<Place, PlaceModel>().ReverseMap();
            CreateMap<QuestionType, QuestionTypeModel>().ReverseMap();
            CreateMap<Schedule, ScheduleModel>().ReverseMap();
        }
    }
}