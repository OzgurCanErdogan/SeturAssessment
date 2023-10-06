using AutoMapper;
using ReportApplication.Dtos;
using ReportApplication.Models;
using System;

namespace ReportApplication.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportsReadDto>();


        }
    }
}
