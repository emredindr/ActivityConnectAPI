using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class AuthorActivity:Entity<int>
{
    public string Author { get; set; }
    public string Translator { get; set; }
    public string DirectedBy { get; set; }
}
