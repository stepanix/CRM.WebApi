using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IProductRetailAuditRepository : IBaseRepository<ProductRetailAudit>
    {
        Task<IEnumerable<ProductRetailAudit>> GetProductRetailAudits();
        Task<ProductRetailAudit> GetProductRetailAudit(int id);
        Task<ProductRetailAudit> InsertProductRetailAudit(ProductRetailAudit productRetailAudit);
        Task<ProductRetailAudit> UpdateProductRetailAudit(ProductRetailAudit productRetailAudit);
        void DeleteProductRetailAudit(int id);
    }
}
