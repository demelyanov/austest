using AusTest.Domain.Model;
using AusTest.Service.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AusTest.Service.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Requirement, RequirementDto>();
            this.CreateMap<RequirementDto, Requirement>();
        }
    }
}
