using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.VisitLogs
{
    public interface IVisitLogService
    {
        Task<IEnumerable<VisitLogModel>> GetVisitLogsAsync();
        Task<VisitLogModel> GetVisitLogAsync(int scheduleid);
        Task<VisitLogModel> InsertVisitLogAsync(VisitLogModel visitlog);
        Task<VisitLogModel> UpdateVisitLogAsync(VisitLogModel visitlog);
        void DeleteVisitLog(int id);
    }
}
