using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Statuses
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusModel>> GetStatusesAsync();
        Task<StatusModel> GetStatusAsync(int id);
        Task<StatusModel> InsertStatusAsync(StatusModel status);
        Task<StatusModel> UpdateStatusAsync(StatusModel status);
        void DeleteStatus(int id);
    }
}
