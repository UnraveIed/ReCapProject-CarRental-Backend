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

            RuleFor(x => x.FindexPoint)
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(1900)
                .WithMessage("Findeks puani 0 ile 1900 arasinda olmalidir!");
        }
    }
}
