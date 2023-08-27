using ActivityConnect.Core.Constants;
using ActivityConnect.Core.ViewModels.AddressVM;
using FluentValidation;

namespace ActivityConnect.Business.ValidationRules.FluentValidation.Adress
{
    public class CreateAddressInputValidator : AbstractValidator<CreateAddressInput>
    {
        public CreateAddressInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength50).WithMessage("Name 50 karakterden fazla olamaz");

            RuleFor(x => x.CityId).NotEmpty()
                .WithMessage("İl alanı zorunludur.")
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.DistrictId).NotEmpty()
                .WithMessage("İlçe alanı zorunludur.")
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.Longitude).NotEmpty()
                .WithMessage("Boylam alanı zorunludur.");

            RuleFor(x => x.Latitude).NotEmpty()
                .WithMessage("Enlem alanı zorunludur.");

            RuleFor(x => x.OpenAddress).NotEmpty().WithMessage("Açık adres alanı zorunludur.").MaximumLength(CoreConsts.MaxLength300).WithMessage("Açık adres 300 karakterden fazla olamaz");
        }
    }
}
