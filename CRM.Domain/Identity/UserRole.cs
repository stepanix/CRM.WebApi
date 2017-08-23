using Microsoft.AspNet.Identity.EntityFramework;

namespace CRM.Domain.Identity
{
    public class UserRole : IdentityUserRole
    {
        public int Id { get; set; }
    }
}
