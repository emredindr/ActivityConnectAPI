using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.ViewModels.PermissionVM;
using ActivityConnect.Core.ViewModels.UserVM;
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

        }
    }
}
