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
    public class StatusRepository : ORMBaseRepository<Status, int>, IStatusRepository
    {
        IRequestIdentityProvider requestIdentityProvider;
        public StatusRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteStatus(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Status> GetStatus(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Status>> GetStatuses()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Statuses
               .Where(t => t.TenantId == user.TenantId)
               .ToListAsync();
        }

        public Task<Status> InsertStatus(Status status)
        {
            throw new NotImplementedException();
        }

        public Task<Status> UpdateStatus(Status status)
        {
            throw new NotImplementedException();
        }
    }
}
