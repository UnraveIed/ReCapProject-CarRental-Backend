using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IPaymentService
    {
        IResult RentCarPay();
        bool CheckCode(int code);
    }
}
