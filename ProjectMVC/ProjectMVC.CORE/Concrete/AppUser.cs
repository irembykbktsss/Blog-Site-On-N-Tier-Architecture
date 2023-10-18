﻿using Microsoft.AspNetCore.Identity;
using ProjectMVC.CORE.Abstract;
using ProjectMVC.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.CORE.Concrete
{
    public class AppUser : IdentityUser , IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get ; set ; } = DateTime.Now;
        public DateTime? UpdatedDate { get ; set ; }
        public DateTime? DeletedDate { get ; set ; }
        public Status Status { get; set; } = Status.Active;

        //nav prop
        public virtual ICollection<Article> Articles { get; set; }
    }
}
