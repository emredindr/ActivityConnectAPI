using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.ViewModels.ActivityDocumentVM;
using ActivityConnect.Core.ViewModels.ActivityVM;
using ActivityConnect.Core.ViewModels.AddressVM;
using ActivityConnect.Core.ViewModels.AddressVM.Dtos;
using ActivityConnect.Core.ViewModels.AuthorActivityVM;
using ActivityConnect.Core.ViewModels.PermissionVM;
using ActivityConnect.Core.ViewModels.UserVM;
using ActivityConnect.Core.ViewModels.VenueDocumentVM;
using ActivityConnect.Core.ViewModels.VenueVM;
using ActivityConnect.Core.ViewModels.VenueVM.Dtos;
using AutoMapper;

namespace ActivityConnect.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            //ReverseMap çift yonlüdönüşümü sağlar.
            //Veritabanına ismen karsılık gelmeyen member için custom ayar yapıldı.
            //CreateMap<User, GetAllUserInfo>().ForMember(k => k.SurnSdame, opt => opt.MapFrom(a => a.Surname)).ReverseMap();
            //User
            CreateMap<GetAllUserInfo, User>().ReverseMap();
            CreateMap<User, CreateUserInput>().ReverseMap();
            CreateMap<User, UpdateUserInput>().ReverseMap();
            CreateMap<User, UserLoginOutput>().ReverseMap();


            //Permission
            CreateMap<Permission, GetAllPermissionInfo>().ReverseMap();
            CreateMap<Permission, CreatePermissionInput>().ReverseMap();
            CreateMap<Permission, UpdatePermissionInput>().ReverseMap();

            //Address
            CreateMap<Address, CreateAddressInput>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();

            //Venue
            CreateMap<Venue, CreateVenueInput>().ReverseMap();
            CreateMap<Venue, VenueDto>().ReverseMap();

            //VenueDocument
            CreateMap<VenueDocument, CreateVenueDocumentInput>().ReverseMap();

            //ActivityDocument
            CreateMap<ActivityDocument, CreateActivityDocumentInput>().ReverseMap();

            
            //AuthorActivity
            CreateMap<AuthorActivity, CreateAuthorActivityInput>().ReverseMap();

            //Activity
            CreateMap<Activity, CreateActivityInput>().ReverseMap();
            CreateMap<Activity, GetAllActivityInfo>().ReverseMap();

        }
    }
}
