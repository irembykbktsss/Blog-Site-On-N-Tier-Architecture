using AutoMapper;
using ProjectMVC.BLL.DTOs.AppUserDTOs;
using ProjectMVC.CORE.Concrete;
using ProjectMVC.UI.Models.VMs.AppUserVMs;

namespace ProjectMVC.UI.Mapping.AppUserMapping
{
    public class AppUserMapping : Profile
    {
        public AppUserMapping()
        {
            CreateMap<RegisterDTO, RegisterVM>().ReverseMap();
            CreateMap<LoginDTO, LoginVM>().ReverseMap();
            CreateMap<AppUserUpdateDTO, AppUserUpdateVM>().ReverseMap();
            CreateMap<AppUserListDTO, AppUserListVM>().ReverseMap();
            CreateMap<AppUserListDTO, AppUserUpdateVM>().ReverseMap();
        }
    }
}
