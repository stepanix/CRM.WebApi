using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IFormValueRepository : IBaseRepository<FormValue>
    {
        Task<IEnumerable<FormValue>> GetFormValues();
        Task<IEnumerable<FormValue>> GetFormValues(DateTime dateFrom, DateTime dateTo,string rep,int place);
        Task<IEnumerable<FormValue>> GetFormValues(DateTime dateFrom, DateTime dateTo, int place);
        Task<IEnumerable<FormValue>> GetFormValues(DateTime dateFrom, DateTime dateTo, string rep);
        Task<IEnumerable<FormValue>> GetFormValues(DateTime dateFrom, DateTime dateTo);
        IEnumerable<FormValue> InsertFormValueList(IEnumerable<FormValue> formValues);
        Task<FormValue> GetFormValue(int id);
        Task<FormValue> GetFormValue(string repoId);
        Task<FormValue> InsertFormValue(FormValue formValue);
        Task<FormValue> UpdateFormValue(FormValue formValue);
        void DeleteFormValue(int id);
    }
}
