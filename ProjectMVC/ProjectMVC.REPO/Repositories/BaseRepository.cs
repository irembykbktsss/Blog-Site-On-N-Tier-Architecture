using Microsoft.EntityFrameworkCore;
using ProjectMVC.CORE.Repositories;
using ProjectMVC.REPO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.REPO.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _contex;
        private readonly DbSet<T> _table;

        public BaseRepository(AppDbContext contex)
        {
            _contex = contex;
            _table = _contex.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _table.AddRangeAsync(entity);
            return await _contex.SaveChangesAsync() > 0;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _table.Remove(entity);
            return await _contex.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return await _table.FirstOrDefaultAsync(expression);
        }

        public bool Update(T entity)
        {
            _table.Update(entity);
            return _contex.SaveChanges() > 0;
        }
    }
}
