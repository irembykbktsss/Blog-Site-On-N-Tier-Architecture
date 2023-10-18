using AutoMapper;
using ProjectMVC.BLL.DTOs.ArticleDTOs;
using ProjectMVC.UI.Models.VMs.ArticleVMs;

namespace ProjectMVC.UI.Mapping.ArticleMapping
{
    public class ArticleMapping : Profile
    {
        public ArticleMapping()
        {
            CreateMap<ArticleListDTO, ArticleListVM>().ReverseMap();
            CreateMap<ArticleCreateDTO, ArticleCreateVM>()
                .ForMember(dest => dest.Subjects , opt => opt.Ignore())
                .ReverseMap();
            CreateMap<ArticleUpdateDTO, ArticleUpdateVM>().ReverseMap();
            CreateMap<ArticleListDTO, ArticleUpdateVM>().ReverseMap();
           

        }
    }
}
