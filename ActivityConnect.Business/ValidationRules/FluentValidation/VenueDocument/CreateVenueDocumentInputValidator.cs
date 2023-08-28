using ActivityConnect.Core.ViewModels.VenueDocumentVM;
using FluentValidation;

namespace ActivityConnect.Business.ValidationRules.FluentValidation.VenueDocument;

public class CreateVenueDocumentInputValidator : AbstractValidator<CreateVenueDocumentInput>
{
	public CreateVenueDocumentInputValidator()
	{
        RuleFor(x => x.DocumentId).GreaterThanOrEqualTo(1).WithMessage("Döküman bilgisi bulunamadı").NotEmpty().WithMessage("Doküman bilgisi gereklidir.");
        RuleFor(x => x.VenueId).GreaterThanOrEqualTo(1).WithMessage("Mekan bilgisi seçilmelidir").NotEmpty().WithMessage("Mekan bilgisi gereklidir.");
    }
}
