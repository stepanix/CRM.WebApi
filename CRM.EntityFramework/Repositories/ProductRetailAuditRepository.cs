using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories
{
    public class ProductRetailAuditRepository : ORMBaseRepository<ProductRetailAudit, int>, IProductRetailAuditRepository
    {
        public ProductRetailAuditRepository(DataContext context) : base(context)
        {
        }

        public void DeleteProductRetailAudit(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductRetailAudit> GetProductRetailAudit(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits()
        {
            throw new NotImplementedException();
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
