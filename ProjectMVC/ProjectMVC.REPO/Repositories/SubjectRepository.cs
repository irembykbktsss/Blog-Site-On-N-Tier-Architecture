using ProjectMVC.CORE.Concrete;
using ProjectMVC.CORE.Repositories;
using ProjectMVC.REPO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.REPO.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AppDbContext contex) : base(contex)
        {
        }
    }
}
