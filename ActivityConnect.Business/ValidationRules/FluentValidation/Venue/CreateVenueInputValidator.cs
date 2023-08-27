using ActivityConnect.Core.Constants;
using ActivityConnect.Core.ViewModels.VenueVM;
using FluentValidation;

namespace ActivityConnect.Business.ValidationRules.FluentValidation.Venue;

public class CreateVenueInputValidator : AbstractValidator<CreateVenueInput>
{
    public CreateVenueInputValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength100).WithMessage("Name 100 karakterden fazla olamaz");

        //RuleFor(x => x.).NotEmpty()
        //    .WithMessage("Address alanı zorunludur.")
        //    .GreaterThanOrEqualTo(1);

        RuleFor(x => x.SeatCapacity).NotEmpty()
            .WithMessage("İlçe alanı zorunludur.");

        RuleFor(x => x.PhoneNumber).NotEmpty()
            .WithMessage("Telefon numarası zorunludur.");
    }
}
