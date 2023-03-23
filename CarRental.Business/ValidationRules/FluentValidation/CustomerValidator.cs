using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x=>x.UserId).NotEmpty();

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .MinimumLength(2);
        }
    }
}
