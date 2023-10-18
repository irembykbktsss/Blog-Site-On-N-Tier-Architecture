using ProjectMVC.CORE.Concrete;
using System.ComponentModel;

namespace ProjectMVC.UI.Models.VMs.ArticleVMs
{
    public class ArticleListVM
    {
        public int Id { get; set; }

        [DisplayName("Başlık")]
        public string Title { get; set; }
      

        [DisplayName("Okunma süresi")]
        public double? AvgReadTime { get; set; }

        [DisplayName("Yazılma Tarihi")]
        public DateTime CreatedDate { get; set; }

        public Subject Subject { get; set; }
        public AppUser AppUser { get; set; }
    }
}
