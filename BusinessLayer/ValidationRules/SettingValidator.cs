using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SettingValidator : AbstractValidator<Setting>
    {
        public SettingValidator()
        {
            RuleFor(x => x.SettingName)
                .NotEmpty().WithMessage("ad alanı boş olamaz")
                .MinimumLength(2).WithMessage("en az 2 karakter girin")
                .MaximumLength(50).WithMessage("en fazla 50 karakter girin");

            RuleFor(x => x.SettingValue)
                .NotEmpty().WithMessage("değer alanı boş olamaz");



        }
    }
}
