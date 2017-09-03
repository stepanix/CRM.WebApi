using CRM.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Identity
{
    public class User : IdentityUser<string, UserLogin, UserRole, UserClaim>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Tenant")]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
