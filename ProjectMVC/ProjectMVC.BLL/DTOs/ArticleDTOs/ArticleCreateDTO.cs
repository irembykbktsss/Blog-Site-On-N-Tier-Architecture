using ProjectMVC.BLL.DTOs.SubjectDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.DTOs.ArticleDTOs
{
    public class ArticleCreateDTO
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public double? AvgReadTime { get; set; }
       
        public int SubjectId { get; set; }
        public string AppUserId { get; set; }

        public List<SubjectListDTO> Subjects { get; set; }
    }
}
