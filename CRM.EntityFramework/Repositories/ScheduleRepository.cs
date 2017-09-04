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
    public class ScheduleRepository : ORMBaseRepository<Schedule, int>, IScheduleRepository
    {
        IRequestIdentityProvider requestIdentityProvider;
        public ScheduleRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> GetSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Schedule>> GetSchedules()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Schedules
               .Where(t => t.TenantId == user.TenantId)
               .ToListAsync();
        }

        public Task<Schedule> InsertSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> UpdateSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
