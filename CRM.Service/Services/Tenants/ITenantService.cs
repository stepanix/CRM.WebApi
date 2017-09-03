

using CRM.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Tenants
{
    public interface ITenantService
    {
        Task<IEnumerable<TenantModel>> GetTenantsAsync();
        Task<TenantModel> GetTenantAsync(int id);
        Task<TenantModel> InsertTenantAsync(TenantModel tenant);
        Task<TenantModel> UpdateTenantAsync(TenantModel tenant);
        void DeleteTenant(int id);
    }
}
