using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IActivityRepository : IBaseRepository<Activity>
    {
        Task<IEnumerable<Activity>> GetActivities();
        Task<IEnumerable<Activity>> GetActivities(string userId,DateTime dateFrom,DateTime dateTo,int placeId);
        IEnumerable<Activity> InsertActivityList(IEnumerable<Activity> activities);
    }
}
