using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Interface
{
    public interface IBaseService<T> where T : class
    {
        Task AddAsync(T entity);
        Task DeleteAsync(long id);
        Task<T> GetAsync(long id);  
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
