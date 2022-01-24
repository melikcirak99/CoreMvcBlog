using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserFirstName)
                .NotEmpty().WithMessage("adı boş olamaz")
                .MinimumLength(2).WithMessage("en az 2 karakter girin")
                .MaximumLength(25).WithMessage("en fazla 25 karakter girin");

            RuleFor(x => x.UserLastName)
                .NotEmpty().WithMessage("soyadı boş olamaz")
                .MinimumLength(2).WithMessage("en az 2 karakter")
                .MaximumLength(25).WithMessage("en fazla 25 karakter girin");

            RuleFor(x => x.UserMail)
                .EmailAddress().WithMessage("geçerli bir email adresi girin")
                .NotEmpty().WithMessage("email boş olamaz")
                .MaximumLength(100).WithMessage("en fazla 100 karakter girin");

            RuleFor(x => x.UserPassword)
                .NotEmpty().WithMessage("şifre boş olamaz")
                .MinimumLength(8).WithMessage("en az 8 karakter girin")
                .MaximumLength(25).WithMessage("en fazla 25 karakter girin");


        }
    }
}
