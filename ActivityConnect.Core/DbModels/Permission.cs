using ActivityConnect.Core.Entities.Audit;

namespace ActivityConnect.Core.DbModels;

public class Permission : FullAudited<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
