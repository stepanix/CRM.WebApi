using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
