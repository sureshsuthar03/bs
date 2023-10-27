using EntitiesLayer.DTOs.Request;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Interface
{
    public interface IProductService:IBaseService<Product>
    {
        Task Create(ProductDTO productDetails);
        Task<Product> GetById(long id);
        Task<IEnumerable<Product>> GetList();
        Task Update(ProductDTO productDetails,long id);
        Task Delete(long id);
    }
}
