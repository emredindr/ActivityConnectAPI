namespace ActivityConnect.Core.ViewModels.AddressVM.Dtos;

public class AddressDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string OpenAddress { get; set; }
    public string DistrictName { get; set; }
    public int CityId { get; set; }
    public string CityName { get; set; }
}
