using BillingSystemServer.ValidationFilter;
using BusinessAccessLayer.Services.Interface;
using BussinessAccessLayer.Utils;
using CommanLayer.Messages;
using EntitiesLayer.DTOs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BillingSystemServer.Areas.Admin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private const string V = "{id:long}";
        public readonly IProductService _productService;
        public ProductController(IProductService productService) 
        {
            _productService = productService;   
        }

        [HttpPost("Create")]
        [ValidationModel]
        public async Task<IActionResult> Create(ProductDTO productDetails)
        {
            await _productService.Create(productDetails);
            return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK,ResponseMsg.Create); 
        }

        [HttpGet("GetList")]
        [ValidationModel]
        public async Task<IActionResult> GetList()
        {
            return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK, ResponseMsg.DataFatch,
                await _productService.GetList());
        }

        [HttpGet(V)]
        [ValidationModel]
        public async Task<IActionResult> GetById(long id)
        {
            return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK, ResponseMsg.DataFatch,
                await _productService.GetById(id));
        }

        [HttpPut(V)]
        [ValidationModel]
        public async Task<IActionResult> Update(ProductDTO productDetails,long id)
        {
            await _productService.Update(productDetails,id);
            return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK, ResponseMsg.Update);
        }

        [HttpDelete(V)]
        [ValidationModel]
        public async Task<IActionResult> Delete(long id)
        {
            await _productService.Delete(id);
            return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK, ResponseMsg.Delete);
        }
    }
}
