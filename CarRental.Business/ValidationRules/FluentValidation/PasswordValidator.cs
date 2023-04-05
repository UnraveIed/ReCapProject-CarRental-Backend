using CarRental.Entities.Dtos;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class PasswordValidator : AbstractValidator<ChangePasswordDto>
    {
        public PasswordValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("Kullanici id hatasi!");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty()
                .WithMessage("Eski sifre bos birakilamaz!");

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .WithMessage("Yeni sifre alani bos birakilamaz!");


            RuleFor(x => x.RepeatPassword)
                .NotEmpty()
                .WithMessage("Sifre tekrari bos birakilamaz!");

            RuleFor(x => x.RepeatPassword)
                .Equal(x => x.NewPassword)
                .WithMessage("Sifreler eslesmemektedir!");
        }
    }
}
