using Microsoft.AspNet.Identity.EntityFramework;


namespace CRM.Domain.Identity
{
    public class UserLogin : IdentityUserLogin
    {
        public int Id { get; set; }
    }
}
