using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public class Invoice:BaseModel
    {
        [Column("product_id")]
        public long ProductId { get; set; }

        [Column("user_id")]
        public long UserId { get; set; }

        [Column("quantiy_sold")]
        public long QuantitySold { get; set; }

        [Column("amount")]
        public long Amount { get; set; }

        [Column("discount")]
        public long Discount { get; set; }

        [Column("tax")]
        public long Tax { get; set; }

        [Column("total_amount")]
        public long TotalAmount { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
