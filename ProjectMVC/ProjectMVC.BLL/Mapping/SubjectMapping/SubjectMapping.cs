using AutoMapper;
using ProjectMVC.BLL.DTOs.SubjectDTOs;
using ProjectMVC.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.Mapping.SubjectMapping
{
    public class SubjectMapping : Profile
    {
        public SubjectMapping()
        {
            CreateMap<Subject, SubjectListDTO>().ReverseMap();
            CreateMap<Subject, SubjectCreateDTO>().ReverseMap();
            CreateMap<Subject, SubjectUpdateDTO>().ReverseMap();
        }
    }
}
