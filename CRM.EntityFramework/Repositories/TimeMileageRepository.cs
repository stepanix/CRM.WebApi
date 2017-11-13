using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using CRM.Domain.RequestIdentity;
using System.Linq;
using System.Data.Entity;

namespace CRM.EntityFramework.Repositories
{
    public class TimeMileageRepository : ORMBaseRepository<TimeMileage, int>, ITimeMileageRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public TimeMileageRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public async Task<TimeMileage> GetTimeMileage(DateTime dateCreated)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .TimeMileages
               .Where(t => t.TenantId == user.TenantId && DbFunctions.TruncateTime(t.DateCreated) == dateCreated && t.UserId== user.Id)
               .Include(u => u.CreatorUser)
               .FirstOrDefaultAsync();
        }

        public Task<TimeMileage> GetTimeMileage(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TimeMileage>> GetTimeMileage(DateTime dateFrom, DateTime dateTo)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .TimeMileages
               .Where(t => t.TenantId == user.TenantId && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo))
               .Include(u=>u.CreatorUser)
               .ToListAsync();
        }

        public async Task<IEnumerable<TimeMileage>> GetTimeMileage(DateTime dateFrom, DateTime dateTo, int place)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TimeMileage>> GetTimeMileage(DateTime dateFrom, DateTime dateTo, string rep)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .TimeMileages
               .Where(t => t.TenantId == user.TenantId && (DbFunctions.TruncateTime(t.DateCreated) >= dateFrom && DbFunctions.TruncateTime(t.DateCreated) <= dateTo)
               && t.CreatorUserId == rep)
               .Include(u=>u.CreatorUser)
               .ToListAsync();
        }

        public Task<IEnumerable<TimeMileage>> GetTimeMileage(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TimeMileage>> GetTimeMileages()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .TimeMileages
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false)
               .ToListAsync();
        }

        public Task<TimeMileage> InsertTimeMileage(TimeMileage timeMileage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TimeMileage> InsertTimeMileageList(IEnumerable<TimeMileage> timeMileages)
        {
            GetDataContext().TimeMileages.AddRange(timeMileages);
            return timeMileages;
        }

        public Task<TimeMileage> UpdateTimeMileage(TimeMileage timeMileage)
        {
            throw new NotImplementedException();
        }
    }
}
