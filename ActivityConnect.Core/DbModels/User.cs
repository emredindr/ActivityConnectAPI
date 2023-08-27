using ActivityConnect.Core.Entities.Audit;

namespace ActivityConnect.Core.DbModels
{
    public class User : FullAudited<int>, IPassivable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool IsActive { get; set; }

    }
}
