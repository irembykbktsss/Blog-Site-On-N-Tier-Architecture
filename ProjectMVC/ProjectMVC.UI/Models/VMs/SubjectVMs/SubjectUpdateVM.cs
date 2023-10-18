using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.UI.Models.VMs.SubjectVMs
{
    public class SubjectUpdateVM
    {
        public int Id { get; set; }

        [DisplayName("Konu Adı")]
        [Required(ErrorMessage = "Konu adı giriniz.")]
        public string SubjectName { get; set; }
    }
}
