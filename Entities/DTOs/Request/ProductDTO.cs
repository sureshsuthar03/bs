using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs.Request
{
    public class ProductDTO:BaseValidationModel<ProductDTO>
    {
        public string Name { get; set; } = null!;
        
        public string? Description { get; set; }

        public string? Category { get; set; }

        public long Price { get; set; }
    }
}
