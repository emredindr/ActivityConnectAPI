namespace ActivityConnect.Core.ViewModels.AddressVM;

public class CreateAddressInput
{
    public string Name { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string OpenAddress { get; set; }
}
