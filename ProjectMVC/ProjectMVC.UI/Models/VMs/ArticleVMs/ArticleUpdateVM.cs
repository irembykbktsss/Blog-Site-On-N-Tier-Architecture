using Microsoft.Build.Framework;
using ProjectMVC.BLL.DTOs.SubjectDTOs;
using ProjectMVC.CORE.Concrete;
using ProjectMVC.UI.Models.VMs.SubjectVMs;
using System.ComponentModel;

namespace ProjectMVC.UI.Models.VMs.ArticleVMs
{
    public class ArticleUpdateVM
    {
        public int Id { get; set; }

        [DisplayName("Başlık")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Başlık giriniz.")]
        public string Title { get; set; }

        [DisplayName("Detay")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Detay giriniz.")]
        public string Detail { get; set; }

        [DisplayName("Okunma Süresi")]
        public double? AvgReadTime { get; set; }

        [DisplayName("Konu")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Konu seçiniz.")]
        public int SubjectId { get; set; }

        public Subject? Subject { get; set; }

        [DisplayName("Yazar")]
        public string AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        public List<SubjectListVM>? Subjects { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
