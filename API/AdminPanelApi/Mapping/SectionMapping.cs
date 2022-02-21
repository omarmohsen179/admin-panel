using AdminPanelApi.DTOs;
using AdminPanelApi.Models;
using AutoMapper;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Mapping
{
    public class SectionMapping : Profile
    {
        public SectionMapping()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            CreateMap<SectionDto, Section>().ForMember(des => des.Text,
                op => op.MapFrom(src => js.Deserialize<IEnumerable<Text>>(src.Text))
                ).ForMember(des => des.Image,
                op => op.MapFrom(src => js.Deserialize<SectionImages>(src.Image))
                ).ReverseMap();
        }

    
}
}
