using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Schedules
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(DateTime date);
        Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(bool isVisited, bool isScheduled, DateTime date);
        Task<IEnumerable<ScheduleModel>> GetMySchedulesAsync(DateTime date);
        Task<ScheduleModel> GetScheduleAsync(int id);
        Task<ScheduleModel> InsertScheduleAsync(ScheduleModel schedule);
        Task<ScheduleModel> UpdateScheduleAsync(ScheduleModel shedule);
        void DeleteSchedule(int id);
    }
}
