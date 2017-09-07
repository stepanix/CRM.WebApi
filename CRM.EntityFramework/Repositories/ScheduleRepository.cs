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

        public async Task<IEnumerable<Schedule>> GetMissedSchedules()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Schedules
               .Where(t => t.TenantId == user.TenantId && t.IsVisited == false)
               .Include(p => p.Place)
               .Include(u => u.User)
               .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetMySchedules(DateTime date)
        {
            return await GetDataContext()
               .Schedules
               .Where(u => u.UserId == requestIdentityProvider.UserId)
               .Include(p => p.Place)
               .ToListAsync();
        }

        public Task<Schedule> GetSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Schedule>> GetSchedules(DateTime date)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Schedules
               .Where(t => t.TenantId == user.TenantId)
               .Include(p => p.Place)
               .Include(u => u.User)
               .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetSchedules(bool isVisited, bool isScheduled, DateTime date)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Schedules
               .Where( t => t.TenantId == user.TenantId  && (t.IsScheduled==isScheduled || t.IsVisited==isVisited))
               .Include(p => p.Place)
               .Include(u => u.User)
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
