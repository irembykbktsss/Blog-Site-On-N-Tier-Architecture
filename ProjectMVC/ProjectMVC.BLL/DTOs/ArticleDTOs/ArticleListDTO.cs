using ProjectMVC.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.DTOs.ArticleDTOs
{
    public class ArticleListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public double? AvgReadTime { get; set; }

        //yazılma tarihi
        public DateTime CreatedDate { get; set; }

        public Subject Subject { get; set; }
        public AppUser AppUser { get; set; }
    }
}
