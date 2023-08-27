using ActivityConnect.Core.ViewModels.UserVM;
using FluentValidation;

namespace ActivityConnect.Business.ValidationRules.FluentValidation.User;

public class UserRegisterInputValidator : AbstractValidator<UserRegisterInput>
{
    public UserRegisterInputValidator()
    {
        RuleFor(s => s.Name).NotEmpty().WithMessage("Ad alanı zorunludur.");

        RuleFor(s => s.Surname).NotEmpty().WithMessage("Soyad zorunludur");

        RuleFor(s => s.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı zorunludur.");

        RuleFor(s => s.Email).NotEmpty().WithMessage("Email alanı zorunludur.")
               .EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Sifre alanı zorunludur !")
                    .MinimumLength(8).WithMessage("En az 8 karakter girmek zorunludur !")
                    .MaximumLength(16).WithMessage("En fazla 16 girilebilir !");

    }
}