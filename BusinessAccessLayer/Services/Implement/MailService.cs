using AutoMapper.Internal;
using BusinessAccessLayer.Services.Interface;
using EntitiesLayer.DTOs.Request;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Implement
{
    public class MailService : IMailService
    {
        private readonly MailSettingDTO _mailSetting;
        public MailService(IOptions<MailSettingDTO> mailSetting)
        {
            _mailSetting = mailSetting.Value;
        }

        public async Task SendMailAsync(MailDTO mailData)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSetting.Mail);
            email.To.Add(MailboxAddress.Parse(mailData.ToEmail));

            if (!mailData.Subject.IsNullOrEmpty()) { email.Subject = mailData.Subject; }            
            else { email.Subject = "Reset password || Billing System || noreply email"; }
            
            var builder=new BodyBuilder();
            if (mailData.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailData.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailData.Body;   
            email.Body=builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSetting.Host,_mailSetting.Port,SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSetting.Mail, _mailSetting.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
