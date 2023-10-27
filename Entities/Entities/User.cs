using CommanLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public class User:BaseModel
    {
        [Column("name")]
        public string? Name { get; set; }

        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("password")]
        public string? Password { get; set; }

        [Column("status")]
        public UserStatus Status { get; set; }

        [Column("role")]
        public UserRole Role { get; set; }
    }
}
