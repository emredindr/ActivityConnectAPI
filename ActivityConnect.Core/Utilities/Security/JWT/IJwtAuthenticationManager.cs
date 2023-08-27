using ActivityConnect.Core.DbModels;

namespace ActivityConnect.Core.Utilities.Security.JWT
{
    public interface IJwtAuthenticationManager
    {
        AccessToken CreateToken(User user, List<Permission> operationClaims);
    }
}
