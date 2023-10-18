using AutoMapper;
using ProjectMVC.BLL.DTOs.ArticleDTOs;
using ProjectMVC.BLL.DTOs.SubjectDTOs;
using ProjectMVC.UI.Models.VMs.ArticleVMs;
using ProjectMVC.UI.Models.VMs.SubjectVMs;

namespace ProjectMVC.UI.Mapping.SubjectMapping
{
    public class SubjectMapping : Profile
    {
        public SubjectMapping()
        {
            CreateMap<SubjectListDTO, SubjectListVM>().ReverseMap();
            CreateMap<SubjectCreateDTO, SubjectCreateVM>().ReverseMap();
            CreateMap<SubjectUpdateDTO, SubjectUpdateVM>().ReverseMap();
            CreateMap<SubjectListDTO, SubjectUpdateVM>().ReverseMap();
        }
    }
}
