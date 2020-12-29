using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using BackEnd.Models;
using System.Threading.Tasks;


namespace BackEnd.Business
{
    public interface IMailer
    {
        Task EnviarEmailAsync(string email, string subeject, string body);
    }
   
    public class Mailer : IMailer
    {
        private readonly SmtpSettings _smptSettings;
        private readonly IWebHostEnvironment _env;
        
        public Mailer (IOptions<SmtpSettings> smtpSettings, IWebHostEnvironment env)
        {
            _smptSettings = smtpSettings.Value;
            _env = env;
        }
       
        public async Task EnviarEmailAsync (string email, string subjetc, string body )
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smptSettings.SenderName, _smptSettings.SenderEmail));
                message.To.Add(MailboxAddress.Parse(email));
                message.Subject = subjetc;
                message.Body = new TextPart("html")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    
                    client.ServerCertificateValidationCallback =  (s, c, h, e) => true;

                    if(_env.IsDevelopment())
                    {
                        await client.ConnectAsync(_smptSettings.Server, _smptSettings.Port, false);
                    }
                    else 
                    {
                        await client.ConnectAsync(_smptSettings.Server);
                    }

                    await client.AuthenticateAsync(_smptSettings.Username, _smptSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (System.Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}