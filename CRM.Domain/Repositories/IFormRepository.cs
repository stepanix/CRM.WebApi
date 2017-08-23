using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IFormRepository : IBaseRepository<Form>
    {
        Task<IEnumerable<Form>> GetForms();
        Task<Form> GetForm(int id);
        Task<Form> InsertForm(Form form);
        Task<Form> UpdateForm(Form form);
        void DeleteForm(int id);
    }
}
