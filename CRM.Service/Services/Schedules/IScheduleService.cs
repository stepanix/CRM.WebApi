using CRM.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Schedules
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleModel>> GetSchedulesAsync();
        Task<IEnumerable<ScheduleModel>> GetMySchedulesAsync();
        Task<ScheduleModel> GetScheduleAsync(int id);
        Task<ScheduleModel> InsertScheduleAsync(ScheduleModel schedule);
        Task<ScheduleModel> UpdateScheduleAsync(ScheduleModel shedule);
        void DeleteSchedule(int id);
    }
}
