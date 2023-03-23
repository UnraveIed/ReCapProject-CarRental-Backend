using CarRental.Business.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class MailManager : IMailService
    {
        private readonly SmtpSettings _smtpSettings;

        public MailManager(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public IResult SendPaymentCode(int code)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress("npbatukan@gmail.com") },
                Subject = "GUVENLIK KODU",
                IsBodyHtml = true,
                Body = $"<h1>RentCar Kiralama Istegi</h1> \n <p>Guvenlik Kodunuz <strong>{code}</strong></p>"
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(message);

            return new SuccessResult("E-Posta başarıyla gönderilmiştir.");
        }

        public IResult Send(EmailSendDto emailSendDto)
        {
            throw new NotImplementedException();
        }

        public IResult SendContactEmail(EmailSendDto emailSendDto)
        {
            throw new NotImplementedException();
        }
    }
}
