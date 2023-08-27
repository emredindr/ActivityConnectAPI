using ActivityConnect.Core.Constants;
using ActivityConnect.Core.ViewModels.PermissionVM;
using FluentValidation;

namespace ActivityConnect.Business.ValidationRules.FluentValidation.Permission
{
    public class UpdatePermissionInputValidator : AbstractValidator<UpdatePermissionInput>
    {
        public UpdatePermissionInputValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength50).WithMessage("Name 50 karakterden fazla olamaz");

            RuleFor(x => x.PermissionGroupId).GreaterThanOrEqualTo(1);
        }
    }
}
