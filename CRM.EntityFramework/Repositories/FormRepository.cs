using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories
{
    public class FormRepository : ORMBaseRepository<Form, int>, IFormRepository
    {

        public FormRepository(DataContext context) : base(context)
        {
        }

        public void DeleteForm(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Form> GetForm(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Form>> GetForms()
        {
            throw new NotImplementedException();
        }

        public Task<Form> InsertForm(Form form)
        {
            throw new NotImplementedException();
        }

        public Task<Form> UpdateForm(Form form)
        {
            throw new NotImplementedException();
        }
    }
}
