using EntitiesLayer.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Interface
{
    public interface IMailService
    {
        Task SendMailAsync(MailDTO mailData);
    }
}
