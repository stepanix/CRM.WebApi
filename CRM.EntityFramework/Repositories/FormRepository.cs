using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using CRM.Domain.RequestIdentity;

namespace CRM.EntityFramework.Repositories
{
    public class FormRepository : ORMBaseRepository<Form, int>, IFormRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public FormRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteForm(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Form> GetForm(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Form>> GetForms()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Forms
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false)
               .ToListAsync();
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
