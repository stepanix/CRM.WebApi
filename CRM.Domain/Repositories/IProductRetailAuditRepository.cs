using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IProductRetailAuditRepository : IBaseRepository<ProductRetailAudit>
    {
        Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits();
        Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits(DateTime dateFrom, DateTime dateTo);
        Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits(DateTime dateFrom, DateTime dateTo, string rep, int place);
        Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits(DateTime dateFrom, DateTime dateTo, string rep);
        Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits(DateTime dateFrom, DateTime dateTo, int place);
        Task<ProductRetailAudit> GetProductRetailAudit(int id);
        Task<ProductRetailAudit> GetProductRetailAudit(string repoId);
        Task<ProductRetailAudit> InsertProductRetailAudit(ProductRetailAudit productRetailAudit);
        IEnumerable<ProductRetailAudit> InsertProductRetailAuditList(IEnumerable<ProductRetailAudit> productRetailAudits);
        Task<ProductRetailAudit> UpdateProductRetailAudit(ProductRetailAudit productRetailAudit);
        void DeleteProductRetailAudit(int id);
    }
}
