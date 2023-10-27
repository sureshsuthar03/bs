using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public class UserRefreshTokens
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? RefreshToken { get; set; }
        public bool IsActive { get; set; }

    }
}
