using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.CORE.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        Task<bool> DeleteAsync(T entity);

        Task<bool> Any(Expression<Func<T, bool>> expression);

        //expression ifadeye göre tek değer döndürme
        Task<T> GetWhere(Expression<Func<T, bool>> expression);

        //expression ifadeye göre list değer döndürme
        Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> expression);
    }
}
