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

        public Task<TimeMileage> GetTimeMileage(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TimeMileage>> GetTimeMileage(DateTime dateFrom, DateTime dateTo)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .TimeMileages
               .Where(t => t.TenantId == user.TenantId && (t.AddedDate >= dateFrom && t.AddedDate <= dateTo))
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
               .Where(t => t.TenantId == user.TenantId && (t.AddedDate >= dateFrom && t.AddedDate <= dateTo)
               && t.CreatorUserId == rep)
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

        public Task<TimeMileage> UpdateTimeMileage(TimeMileage timeMileage)
        {
            throw new NotImplementedException();
        }
    }
}
