using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using CRM.Domain.RequestIdentity;

namespace CRM.EntityFramework.Repositories
{
    public class VisitLogRepository : ORMBaseRepository<VisitLog, int>, IVisitLogRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public VisitLogRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteVisitLog(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VisitLog> GetVisitLog(int scheduleid)
        {
            return await GetDataContext()
               .VisitLogs
               .Where(t => t.ScheduleId == scheduleid)
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<VisitLog>> GetVisitLogs()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .VisitLogs
               .Where(t => t.TenantId == user.TenantId)
               .ToListAsync();
        }

        public Task<VisitLog> InsertVisitLog(VisitLog visitlog)
        {
            throw new NotImplementedException();
        }

        public Task<VisitLog> UpdateVisitLog(VisitLog visitlog)
        {
            throw new NotImplementedException();
        }
    }
}
