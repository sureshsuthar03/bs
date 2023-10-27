using BusinessAccessLayer.Services.Interface;
using DataAccessLayer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Implement
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public readonly IBaseRepository<T> _repo;
        public readonly IUnitOfWork _unitOfWork;

        public BaseService(IBaseRepository<T> repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }   

        public async Task AddAsync(T entity)
        {
            await _repo.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _repo.DeleteAsync(id);   
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<T> GetAsync(long id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _repo.Update(entity);    
            await _unitOfWork.SaveAsync();  
        }
    }
}
