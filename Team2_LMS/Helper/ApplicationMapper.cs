using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Team2_LMS.Models;

namespace Team2_LMS.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<EmployeeModel, EmployeeDB>().ReverseMap();
            CreateMap<CeoModel, CeoDB>().ReverseMap();
            CreateMap<ManagerModel, ManagerDb>().ReverseMap();
        }
    }
}
