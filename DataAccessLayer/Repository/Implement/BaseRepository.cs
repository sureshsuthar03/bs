using DataAccessLayer.ApplicationDbContext;
using DataAccessLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Implement
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly AppDbContext _context;
        public readonly DbSet<T> _dbSet;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity) => _dbSet.Add(entity);

        public async Task DeleteAsync(long id) => _context.Remove(await GetByIdAsync(id));

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = _dbSet;   
            return await query.ToListAsync();   
        }

        public async Task<T> GetByIdAsync(long id) => await _dbSet.FindAsync(id);

        public void Update(T entity) => _dbSet.Update(entity);

        public async Task<IEnumerable<T>> GetAllFiltered(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, IList<Expression<Func<T, object>>>? includes = null,
            int? page = null, int? pageSize = null)
        {
            var query = _dbSet.AsQueryable();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (orderBy != null) query = orderBy(query);
            if (filter != null) query.Where(filter);
            if (page != null && pageSize != null) query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            return await query.ToListAsync();
        }
    }
}
