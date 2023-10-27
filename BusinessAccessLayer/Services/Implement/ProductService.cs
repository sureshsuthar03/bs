using AutoMapper;
using BusinessAccessLayer.Services.Interface;
using DataAccessLayer.Repository.Interface;
using EntitiesLayer.DTOs.Request;
using EntitiesLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Implement
{
    public class ProductService : BaseService<Product>,IProductService
    {
        public readonly IProductRepository _productRepository;
        public readonly IMapper _mapper;
        public new readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository,IMapper mapper,IUnitOfWork unitOfWork):base(productRepository,unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork; 
        }

        public async Task Create(ProductDTO productDetails)
        {
            Product product = _mapper.Map<Product>(productDetails); 
            await AddAsync(product);  
        }

        public async Task<Product> GetById(long id)
        {
            return await GetAsync(id);
        }

        public async Task<IEnumerable<Product>> GetList()
        {
            return await GetAllAsync();
        }

        public async Task Update(ProductDTO productDetails, long id)
        {
            Product product = _mapper.Map<Product>(productDetails);
            product.Id = id;
            await UpdateAsync(product);
        }

        public async Task Delete(long id)
        {
            await DeleteAsync(id);
        }

    }
}
