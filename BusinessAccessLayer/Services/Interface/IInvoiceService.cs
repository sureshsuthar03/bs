using EntitiesLayer.DTOs.Request;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Interface
{
    public interface IInvoiceService:IBaseService<Invoice>
    {
        Task Create(InvoiceDTO productDetails);
        Task<Invoice> GetById(long id);
        Task<IEnumerable<Invoice>> GetList();
        Task Update(InvoiceDTO productDetails, long id);
        Task Delete(long id);
    }
}
