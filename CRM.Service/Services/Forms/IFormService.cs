using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Forms
{
    public interface IFormService
    {
        Task<IEnumerable<FormModel>> GetFormsAsync();
        Task<FormModel> GetFormAsync(int id);
        Task<FormModel> InsertFormAsync(FormModel form);
        Task<FormModel> UpdateFormAsync(FormModel form);
        void DeleteForm(int id);
    }
}
