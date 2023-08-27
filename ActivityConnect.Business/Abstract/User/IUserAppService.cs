using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.UserVM;

namespace ActivityConnect.Business.Abstract
{
    public interface IUserAppService
    {
        Task<GetAllUserInfo> GetUserById(int userId);
        Task<GetAllUserInfo> GetCurrentUserInfo();
        Task<PagedResult<GetAllUserInfo>> GetAllUsersByPage(GetAllUserInput input);
        Task<ListResult<GetAllUserInfo>> GetUserList(GetAllUserInput input);
        Task<UserLoginOutput> Login(UserLoginInput input); 
        Task<UserLoginOutput> Register(UserRegisterInput input);
        Task CreateUser(CreateUserInput input);
        Task UpdateUser(UpdateUserInput input);
        Task UpdateCurrentUserInfo(UpdateUserInput updateUserInput);
        Task DeleteUser(int userId);
    }
}
