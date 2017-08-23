using Microsoft.AspNet.Identity.EntityFramework;


namespace CRM.Domain.Identity
{
    public class User : IdentityUser<string, UserLogin, UserRole, UserClaim>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
