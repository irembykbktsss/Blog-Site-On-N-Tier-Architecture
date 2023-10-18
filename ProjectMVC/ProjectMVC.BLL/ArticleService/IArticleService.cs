using ProjectMVC.BLL.DTOs.ArticleDTOs;
using ProjectMVC.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.ArticleService
{
    public interface IArticleService
    {
        Task<bool> AddAsync(ArticleCreateDTO articleCreateDTO);
        void Update(ArticleUpdateDTO articleUpdateDTO);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ArticleListDTO>> GetAllAsync();           //tüm makaleler
        Task<ArticleListDTO> GetByIdAsync(int id);
        Task<IEnumerable<ArticleListDTO>> GetAllByUserAsync(string UserId);     //usera ait makaleler

        Task<IEnumerable<ArticleListDTO>> GetAllBySubjectAsync(int subjectId);          //konuya göre makaleler

        int CalculateAvgReadTime(string detail);
    }
}
