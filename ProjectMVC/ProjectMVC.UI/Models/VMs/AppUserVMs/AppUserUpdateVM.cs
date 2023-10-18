using System.ComponentModel;

namespace ProjectMVC.UI.Models.VMs.AppUserVMs
{
    public class AppUserUpdateVM
    {
        public string Id { get; set; }

        [DisplayName("Ad")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        public string LastName { get; set; }

        [DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
