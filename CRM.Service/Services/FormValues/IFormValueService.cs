using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.FormValues
{
    public interface IFormValueService
    {
        Task<IEnumerable<FormValueModel>> GetFormValuesAsync();
        Task<IEnumerable<FormValueModel>> GetFormValuesAsync(DateTime dateFrom, DateTime dateTo);
        Task<FormValueModel> GetFormValueAsync(int id);
        Task<FormValueModel> InsertFormValueAsync(FormValueModel formValue);
        Task<FormValueModel> UpdateFormValueAsync(FormValueModel formValue);
        void DeleteFormValue(int id);
    }
}
