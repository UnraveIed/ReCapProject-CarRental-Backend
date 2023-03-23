using CarRental.Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IMailService _mailService;
        private static int paymentCode;

        public PaymentManager(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IResult RentCarPay()
        {
            BuiltCode();
            _mailService.SendPaymentCode(paymentCode);
            Task.Run(() => ResetCodeAuto()); 
            return new SuccessResult("");
        }

        public bool CheckCode (int code)
        {
            if (code == paymentCode)
            {
                ResetCode();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BuiltCode()
        {
            Random rnd = new Random();
            paymentCode = rnd.Next(100000, 999999);
        }

        private void ResetCodeAuto()
        {
            System.Threading.Thread.Sleep(180000);
            paymentCode = 123456789;
        }

        private void ResetCode()
        { 
            paymentCode = 123456789;
        }
    }
}
