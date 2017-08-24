using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IRetailAuditFormRepository : IBaseRepository<RetailAuditForm>
    {
        Task<IEnumerable<RetailAuditForm>> GetRetailAuditForms();
        Task<RetailAuditForm> GetRetailAuditForm(int id);
        Task<RetailAuditForm> InsertRetailAuditForm(RetailAuditForm retailAuditForm);
        Task<RetailAuditForm> UpdateRetailAuditForm(RetailAuditForm retailAuditForm);
        void DeleteRetailAuditForm(int id);
    }
}
