using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectMVC.UI.Models.VMs.AppUserVMs
{
    public class RegisterVM
    {       

        [DisplayName("Email")]
        [Required(ErrorMessage ="Lütfen email giriniz.")]
        public string Email { get; set; }

      
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Maximum 10 minimum 3 karakter olmalı", MinimumLength = 3)]
        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifre tekrarı giriniz.")]
        [DisplayName("Şifre Tekrar:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girilen şifreler uyumlu olmalıdır.")]
        [StringLength(10, ErrorMessage = "Maximum 10 minimum 3 karakter olmalı", MinimumLength = 3)]
        public string ConfirmPassword { get; set; }
    }
}
