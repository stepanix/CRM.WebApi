using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories
{
    public class FormValueRepository : ORMBaseRepository<FormValue, int>, IFormValueRepository
    {
        public FormValueRepository(DataContext context) : base(context)
        {
        }

        public void DeleteFormValue(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FormValue> GetFormValue(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FormValue>> GetFormValues()
        {
            throw new NotImplementedException();
        }

        public Task<FormValue> InsertFormValue(FormValue formValue)
        {
            throw new NotImplementedException();
        }

        public Task<FormValue> UpdateFormValue(FormValue formValue)
        {
            throw new NotImplementedException();
        }
    }
}
