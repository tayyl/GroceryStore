using AutoMapper;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models.Category;

namespace WebApp.App_Start
{
    public class AutoMapperConfig : Profile
    {
       public AutoMapperConfig()
        {
            CreateMap<Category, CategoryOutputModel>()
                .ForMember(x => x.Info, d => d.MapFrom(s => $"{s.Id} {s.Name}"));
            
        }
    }
}