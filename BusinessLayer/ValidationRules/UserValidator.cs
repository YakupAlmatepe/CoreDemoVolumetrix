using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator :AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İsim alanını boş geçemezsiniz.");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail alanını boş geçemezsiniz.");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Şifre alanını boş geçemezsiniz.");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız.");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
        }
    }
}
