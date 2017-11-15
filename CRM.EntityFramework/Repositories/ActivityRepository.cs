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
    public class ActivityRepository : ORMBaseRepository<Activity, int>, IActivityRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public ActivityRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public Task<IEnumerable<Activity>> GetActivities()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Activity>> GetActivities(string userId)
        {
            return await GetDataContext()
             .Activities
             .Where(u => u.UserId == userId && (u.DateCreated.Month == DateTime.Now.Month && u.DateCreated.Year==DateTime.Now.Year))
             .Include(u => u.User)
             .Include(p => p.Place)
             .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetActivities(DateTime dateFrom, DateTime dateTo)
        {
            return await GetDataContext()
             .Activities
             .Where(u => DbFunctions.TruncateTime(u.DateCreated) >= dateFrom && DbFunctions.TruncateTime(u.DateCreated) <= dateTo)
             .Include(u => u.User)
             .Include(p => p.Place)
             .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetActivities(string userId, DateTime dateFrom, DateTime dateTo, int placeId)
        {
            if(placeId == 0)
            {
               return await GetDataContext()
              .Activities
              .Where(u => u.UserId == userId && (DbFunctions.TruncateTime(u.AddedDate) >= dateFrom && DbFunctions.TruncateTime(u.AddedDate) <= dateTo))
              .Include(u=>u.User)
              .Include(p=>p.Place)
              .ToListAsync();
            }else
            {
               return await GetDataContext()
              .Activities
              .Where(u => u.UserId == userId && (DbFunctions.TruncateTime(u.AddedDate) >= dateFrom && DbFunctions.TruncateTime(u.AddedDate) <= dateTo) && u.PlaceId==placeId)
              .Include(u => u.User)
              .Include(p => p.Place)
              .ToListAsync();
            }
        }

        public IEnumerable<Activity> InsertActivityList(IEnumerable<Activity> activities)
        {
            GetDataContext().Activities.AddRange(activities);
            return activities;
        }

    }
}
