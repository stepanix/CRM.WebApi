using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IActivityRepository : IBaseRepository<Activity>
    {
        Task<IEnumerable<Activity>> GetActivities();
        IEnumerable<Activity> InsertActivityList(IEnumerable<Activity> activities);
    }
}
