using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.UI.Models.VMs.AppUserVMs
{
    public class LoginVM
    {
        [DisplayName("Mail ")]
        [Required(ErrorMessage = "Mail adresi zorunludur.")]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage ="Şifre zorunludur.")]
        public string Password { get; set; }
    }
}
