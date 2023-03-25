using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.ModelYear)
                .NotEmpty()
                .LessThanOrEqualTo((short)DateTime.Now.Year).WithMessage("Lutfen gecerli bir yil veriniz!");

            RuleFor(x => x.ColorId)
                .NotEmpty()
                .GreaterThanOrEqualTo(1).WithMessage("Renk degeri 0'dan buyuk olmalidir!");

            RuleFor(x => x.DailyPrice)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Fiyat 0 olamaz!");
        }
    }
}
