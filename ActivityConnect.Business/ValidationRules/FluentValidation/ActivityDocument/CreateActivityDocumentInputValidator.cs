using ActivityConnect.Core.ViewModels.ActivityDocumentVM;
using FluentValidation;

namespace ActivityConnect.Business.ValidationRules.FluentValidation.ActivityDocument;

public class CreateActivityDocumentInputValidator : AbstractValidator<CreateActivityDocumentInput>
{
    public CreateActivityDocumentInputValidator()
    {
        RuleFor(x => x.DocumentId).GreaterThanOrEqualTo(1).WithMessage("Döküman bilgisi bulunamadı").NotEmpty().WithMessage("Doküman bilgisi gereklidir.");
        RuleFor(x => x.ActivityId).GreaterThanOrEqualTo(1).WithMessage("Etkinlik  bilgisi seçilmelidir").NotEmpty().WithMessage("Etkinlik bilgisi gereklidir.");
    }
}
