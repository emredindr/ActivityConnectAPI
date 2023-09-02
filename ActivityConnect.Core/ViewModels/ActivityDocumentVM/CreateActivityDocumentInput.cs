namespace ActivityConnect.Core.ViewModels.ActivityDocumentVM;

public class CreateActivityDocumentInput
{
    public int ActivityId { get; set; }
    public List<int> DocumentIds { get; set; }
    public bool IsDefault { get; set; } = false;
}
