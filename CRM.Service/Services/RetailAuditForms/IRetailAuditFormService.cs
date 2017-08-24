using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.RetailAuditForms
{
    public interface IRetailAuditFormService
    {
        Task<IEnumerable<RetailAuditFormModel>> GetRetailAuditFormsAsync();
        Task<RetailAuditFormModel> GetRetailAuditFormAsync(int id);
        Task<RetailAuditFormModel> InsertRetailAuditFormAsync(RetailAuditFormModel retailAuditForm);
        Task<RetailAuditFormModel> UpdateRetailAuditFormAsync(RetailAuditFormModel retailAuditForm);
        void DeleteRetailAuditForm(int id);
    }
}
