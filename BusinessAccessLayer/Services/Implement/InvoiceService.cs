using AutoMapper;
using BusinessAccessLayer.Services.Interface;
using DataAccessLayer.Repository.Interface;
using EntitiesLayer.DTOs.Request;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Implement
{
    public class InvoiceService:BaseService<Invoice>,IInvoiceService
    {
        public readonly IInvoiceRepository _invoiceRepository;
        public readonly IMapper _mapper;
        public new readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(invoiceRepository, unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(InvoiceDTO invoiceDetails)
        {
            Invoice invoice = _mapper.Map<Invoice>(invoiceDetails);
            await AddAsync(invoice);
        }

        public async Task<Invoice> GetById(long id)
        {
            return await GetAsync(id);
        }

        public async Task<IEnumerable<Invoice>> GetList()
        {
            return await GetAllAsync();
        }

        public async Task Update(InvoiceDTO invoiceDetails, long id)
        {
            Invoice invoice = _mapper.Map<Invoice>(invoiceDetails);
            invoice.Id = id;
            await UpdateAsync(invoice);
        }

        public async Task Delete(long id)
        {
            await DeleteAsync(id);
        }
    }
}
