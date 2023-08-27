using ActivityConnect.Core.ViewModels.AddressVM;

namespace ActivityConnect.Business.Abstract;

public interface IAddressAppService
{
    Task CreateAddress(CreateAddressInput input);
}
