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
    public class FormValueRepository : ORMBaseRepository<FormValue, int>, IFormValueRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public FormValueRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteFormValue(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FormValue> GetFormValue(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FormValue>> GetFormValues()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .FormValues
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false)
               .ToListAsync();
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
