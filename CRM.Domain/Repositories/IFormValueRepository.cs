using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IFormValueRepository : IBaseRepository<FormValue>
    {
        Task<IEnumerable<FormValue>> GetFormValues();
        Task<FormValue> GetFormValue(int id);
        Task<FormValue> InsertFormValue(FormValue formValue);
        Task<FormValue> UpdateFormValue(FormValue formValue);
        void DeleteFormValue(int id);
    }
}
