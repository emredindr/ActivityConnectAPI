using ActivityConnect.Business.Abstract;
using ActivityConnect.Business.ValidationRules.FluentValidation.Adress;
using ActivityConnect.Core.Aspects.AutoFac.Validation;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.ViewModels.AddressVM;

namespace ActivityConnect.Business.Concreate;

public class AddressAppService : BaseAppService,IAddressAppService
{
    private readonly IRepository<Address,int> _addressRepository;

    public AddressAppService(IRepository<Address, int> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    [ValidationAspect(typeof(CreateAddressInputValidator))]
    public async Task CreateAddress(CreateAddressInput input)
    {
        var newAddress = Mapper.Map<Address>(input);
       
        await _addressRepository.InsertAsync(newAddress);
    }
}
