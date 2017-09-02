using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IStatusRepository : IBaseRepository<Status>
    {
        Task<IEnumerable<Status>> GetStatuses();
        Task<Status> GetStatus(int id);
        Task<Status> InsertStatus(Status status);
        Task<Status> UpdateStatus(Status status);
        void DeleteStatus(int id);
    }
}
