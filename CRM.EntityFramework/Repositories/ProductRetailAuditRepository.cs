using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using CRM.Domain.RequestIdentity;


namespace CRM.EntityFramework.Repositories
{
    public class ProductRetailAuditRepository : ORMBaseRepository<ProductRetailAudit, int>, IProductRetailAuditRepository
    {
        IRequestIdentityProvider requestIdentityProvider;
        public ProductRetailAuditRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteProductRetailAudit(int id)
        {
           throw new NotImplementedException();
        }

        public Task<ProductRetailAudit> GetProductRetailAudit(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .ProductRetailAudits
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false)
               .ToListAsync();
        }

        public async Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits(DateTime dateFrom, DateTime dateTo)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .ProductRetailAudits
               .Where(t => t.TenantId == user.TenantId && (t.AddedDate >= dateFrom && t.AddedDate <= dateTo))
               .ToListAsync();
        }

        public async Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits(DateTime dateFrom, DateTime dateTo, int place)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .ProductRetailAudits
               .Where(t => t.TenantId == user.TenantId && (t.AddedDate >= dateFrom && t.AddedDate <= dateTo)
               && t.PlaceId == place
               )
               .ToListAsync();
        }

        public async Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits(DateTime dateFrom, DateTime dateTo, string rep)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .ProductRetailAudits
               .Where(t => t.TenantId == user.TenantId && (t.AddedDate >= dateFrom && t.AddedDate <= dateTo)
               && t.CreatorUserId == rep
               )
               .ToListAsync();
        }

        public async Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .ProductRetailAudits
               .Where(t => t.TenantId == user.TenantId && (t.AddedDate >= dateFrom && t.AddedDate <= dateTo)
               && t.CreatorUserId == rep
               && t.PlaceId == place
               )
               .ToListAsync();
        }

        public Task<ProductRetailAudit> InsertProductRetailAudit(ProductRetailAudit productRetailAudit)
        {
            throw new NotImplementedException();
        }

        public Task<ProductRetailAudit> UpdateProductRetailAudit(ProductRetailAudit productRetailAudit)
        {
            throw new NotImplementedException();
        }
    }
}
