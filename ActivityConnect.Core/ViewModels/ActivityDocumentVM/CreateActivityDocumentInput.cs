namespace ActivityConnect.Core.ViewModels.ActivityDocumentVM;

public class CreateActivityDocumentInput
{
    public int ActivityId { get; set; }
    public int DocumentId { get; set; }
    public bool IsDefault { get; set; } = false;
}
