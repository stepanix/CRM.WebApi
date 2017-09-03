using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface ITenantRepository : IBaseRepository<Tenant>
    {
        Task<IEnumerable<Tenant>> GetTenants();
        Task<Tenant> GetTenant(int id);
        Task<Tenant> InsertTenant(Tenant tenant);
        Task<Tenant> UpdateTenant(Tenant tenant);
        void DeleteTenant(int id);
    }
}
