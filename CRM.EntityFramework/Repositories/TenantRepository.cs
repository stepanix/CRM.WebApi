using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;

namespace CRM.EntityFramework.Repositories
{
    public class TenantRepository : ORMBaseRepository<Tenant, int>, ITenantRepository
    {
        public TenantRepository(DataContext context) : base(context)
        {
        }

        public void DeleteTenant(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tenant> GetTenant(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tenant>> GetTenants()
        {
            throw new NotImplementedException();
        }

        public Task<Tenant> InsertTenant(Tenant tenant)
        {
            throw new NotImplementedException();
        }

        public Task<Tenant> UpdateTenant(Tenant tenant)
        {
            throw new NotImplementedException();
        }
    }
}
