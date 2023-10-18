using AutoMapper;
using ProjectMVC.BLL.DTOs.AppUserDTOs;
using ProjectMVC.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.Mapping.AppUserMapping
{
    public class AppUserMapping : Profile
    {
        public AppUserMapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppUser, LoginDTO>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDTO>().ReverseMap();
            CreateMap<AppUser, AppUserListDTO>().ReverseMap();
        }
    }
}
