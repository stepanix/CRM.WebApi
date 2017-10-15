using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories
{
    public class ActivityRepository : ORMBaseRepository<Activity, int>, IActivityRepository
    {
        public ActivityRepository(DataContext context) : base(context)
        {
        }

        public Task<IEnumerable<Activity>> GetActivities()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> InsertActivityList(IEnumerable<Activity> activities)
        {
            GetDataContext().Activities.AddRange(activities);
            return activities;
        }

    }
}
