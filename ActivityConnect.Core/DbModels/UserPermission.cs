using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class UserPermission : Entity<int>
{
    public int UserId { get; set; }
    public int PermissionId { get; set; }
}
