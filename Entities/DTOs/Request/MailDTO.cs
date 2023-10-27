using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs.Request
{
    public class MailDTO
    {
        public string ToEmail { get; set; } = String.Empty;
        public string Subject { get; set; } = String.Empty; 
        public string Body { get; set; } = String.Empty;
        public List<IFormFile>? Attachments { get; set; }
    }
}
