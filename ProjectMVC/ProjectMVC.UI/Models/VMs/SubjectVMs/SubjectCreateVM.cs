using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.UI.Models.VMs.SubjectVMs
{
    public class SubjectCreateVM
    {
        [DisplayName("Konu Adı")]
        [Required(ErrorMessage ="Konu adı giriniz.")]
        public string SubjectName { get; set; }
    }
}
