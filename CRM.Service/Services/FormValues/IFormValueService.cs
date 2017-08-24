using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.FormValues
{
    public interface IFormValueService
    {
        Task<IEnumerable<FormValueModel>> GetFormValuesAsync();
        Task<FormValueModel> GetFormValueAsync(int id);
        Task<FormValueModel> InsertFormValueAsync(FormValueModel formValue);
        Task<FormValueModel> UpdateFormValueAsync(FormValueModel formValue);
        void DeleteFormValue(int id);
    }
}
