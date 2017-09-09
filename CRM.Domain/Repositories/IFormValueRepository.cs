using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IFormValueRepository : IBaseRepository<FormValue>
    {
        Task<IEnumerable<FormValue>> GetFormValues();
        Task<IEnumerable<FormValue>> GetFormValues(DateTime dateFrom, DateTime dateTo);
        Task<FormValue> GetFormValue(int id);
        Task<FormValue> InsertFormValue(FormValue formValue);
        Task<FormValue> UpdateFormValue(FormValue formValue);
        void DeleteFormValue(int id);
    }
}
