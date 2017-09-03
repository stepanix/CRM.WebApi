

namespace CRM.Domain.Model
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; }
        public int TenantId { get; set; }
    }
}
