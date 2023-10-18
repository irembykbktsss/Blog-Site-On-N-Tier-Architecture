using ProjectMVC.CORE.Abstract;
using ProjectMVC.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.CORE.Concrete
{
    public class Article : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public double? AvgReadTime { get; set; }          //ortalama okuma süresi

        public DateTime CreatedDate { get ; set ; } = DateTime.Now;
        public DateTime? UpdatedDate { get ; set ; }
        public DateTime? DeletedDate { get ; set ; }
        public Status Status { get; set; } = Status.Active;

        public int SubjectId { get; set; }
        public string AppUserId { get; set; }

        //nav prop
        public virtual Subject Subject { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
