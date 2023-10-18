using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.REPO.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //dbsetler
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Article> Articles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    SubjectName = "Programing",
                    CreatedDate = DateTime.Now,
                    Status = CORE.Enums.Status.Active
                },
                 new Subject
                 {
                     Id = 2,
                     SubjectName = "Machine Learning",
                     CreatedDate = DateTime.Now,
                     Status = CORE.Enums.Status.Active
                 },
                  new Subject
                  {
                      Id = 3,
                      SubjectName = "Data Science",
                      CreatedDate = DateTime.Now,
                      Status = CORE.Enums.Status.Active
                  },
                   new Subject
                   {
                       Id = 4,
                       SubjectName = "Technology",
                       CreatedDate = DateTime.Now,
                       Status = CORE.Enums.Status.Active
                   }, new Subject
                   {
                       Id = 5,
                       SubjectName = "Politics",
                       CreatedDate = DateTime.Now,
                       Status = CORE.Enums.Status.Active
                   }
                ); 

            base.OnModelCreating(builder);
        }
    }
    
}
