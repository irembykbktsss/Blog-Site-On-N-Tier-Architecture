using System.ComponentModel;

namespace ProjectMVC.UI.Models.VMs.SubjectVMs
{
    public class SubjectListVM
    {
        public int Id { get; set; }

        [DisplayName("Konu Adı")]
        public string SubjectName { get; set; }
    }
}
