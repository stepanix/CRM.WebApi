
using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.ProductRetailAudits
{
    public interface IProductRetailAuditService
    {
        Task<IEnumerable<ProductRetailAuditModel>> GetProductRetailAuditsAsync();
        Task<IEnumerable<ProductRetailAuditModel>> GetProductRetailAuditsAsync(DateTime dateFrom, DateTime dateTo);
        Task<ProductRetailAuditModel> GetProductRetailAuditAsync(int id);
        Task<ProductRetailAuditModel> InsertProductRetailAuditAsync(ProductRetailAuditModel productRetailAudit);
        Task<ProductRetailAuditModel> UpdateProductRetailAuditAsync(ProductRetailAuditModel productRetailAudit);
        void DeleteProductRetailAudit(int id);
    }
}
