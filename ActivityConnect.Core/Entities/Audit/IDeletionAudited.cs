namespace ActivityConnect.Core.Entities.Audit
{
    public interface IDeletionAudited
    {
        int? DeletorUserId { get; set; }
        DateTime? DeletionTime { get; set; }

    }
}
