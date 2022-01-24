using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("Kategori seçin lütfen");

            RuleFor(x => x.PostContent)
                .NotEmpty().WithMessage("lütfen içerik girin")
                .MinimumLength(5).WithMessage("en az 5 karakter girişi yapılmalı");
            
            RuleFor(x => x.PostSeoTitle)
                .NotEmpty().WithMessage("lütfen seo başlığı girin")
                .MinimumLength(3).WithMessage("en az 3 karakter girişi yapılmalı");
            RuleFor(x => x.PostTitle)
                .NotEmpty().WithMessage("lütfen başlık girin")
                .MinimumLength(3).WithMessage("en az 3 karakter girişi yapılmalı");

            RuleFor(x => x.PostSummary)
                .NotEmpty().WithMessage("lütfen özet girin")
                .MinimumLength(3).WithMessage("en az 3 karakter girişi yapılmalı")
                .MaximumLength(70).WithMessage("en fazla 70 karakter girişi yapın");
            RuleFor(x => x.WriterId)
                .NotNull().WithMessage("yazar bilgisi girilmeli");

                
        }
    }
}
