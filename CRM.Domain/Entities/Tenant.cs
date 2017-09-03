

using CRM.Domain.Entity.Base;

namespace CRM.Domain.Entities
{
    public class Tenant : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
