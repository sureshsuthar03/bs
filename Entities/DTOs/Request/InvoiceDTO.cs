using EntitiesLayer.Abstract;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs.Request
{
    public class InvoiceDTO:BaseValidationModel<InvoiceDTO>
    {
        public long ProductId { get; set; }

        public long UserId { get; set; }

        public long QuantitySold { get; set; }

        public long Amount { get; set; }

        public long Discount { get; set; }

        public long Tax { get; set; }

        public long TotalAmount { get; set; }

        public DateTime Date { get; set; }
    }
}
