using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IRetailAuditFormRepository : IBaseRepository<RetailAuditForm>
    {
        Task<IEnumerable<RetailAuditForm>> GetRetailAuditForms();
        Task<IEnumerable<RetailAuditForm>> GetRetailAuditForms(DateTime dateFrom, DateTime dateTo);
        Task<RetailAuditForm> GetRetailAuditForm(int id);
        Task<RetailAuditForm> InsertRetailAuditForm(RetailAuditForm retailAuditForm);
        Task<RetailAuditForm> UpdateRetailAuditForm(RetailAuditForm retailAuditForm);
        void DeleteRetailAuditForm(int id);
    }
}
