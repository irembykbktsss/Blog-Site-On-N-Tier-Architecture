using AutoMapper;
using ProjectMVC.BLL.DTOs.ArticleDTOs;
using ProjectMVC.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.Mapping.ArticleMapping
{
    public class ArticleMapping : Profile
    {
        public ArticleMapping()
        {
            CreateMap<Article, ArticleListDTO>().ReverseMap();
            CreateMap<Article, ArticleCreateDTO>().ReverseMap();
            CreateMap<Article, ArticleUpdateDTO>().ReverseMap();
        }
    }
}
