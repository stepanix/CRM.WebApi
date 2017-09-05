using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CRM.Domain.Repositories
{
    public interface IVisitLogRepository : IBaseRepository<VisitLog>
    {
        Task<IEnumerable<VisitLog>> GetVisitLogs();
        Task<VisitLog> GetVisitLog(int scheduleid);
        Task<VisitLog> InsertVisitLog(VisitLog visitlog);
        Task<VisitLog> UpdateVisitLog(VisitLog visitlog);
        void DeleteVisitLog(int id);
    }
}
