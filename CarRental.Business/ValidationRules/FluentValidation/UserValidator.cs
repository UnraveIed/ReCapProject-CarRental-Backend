using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x=>x.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(35);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(35);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MinimumLength(5);

            //RuleFor(x => x.Password)
            //    .NotEmpty()
            //    .MinimumLength(5)
            //    .MaximumLength(35);
        }
    }
}
