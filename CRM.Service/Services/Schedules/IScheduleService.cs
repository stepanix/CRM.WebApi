using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Schedules
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleModel>> GetSchedulesAsync();
        Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(DateTime dateFrom, DateTime dateTo);
        Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(DateTime dateFrom, DateTime dateTo, string rep);
        Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(DateTime dateFrom, DateTime dateTo, int place);
        Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(DateTime dateFrom, DateTime dateTo, string rep, int place);
        Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(bool isVisited, bool isScheduled, bool isUnScheduled, bool isMissed);
        Task<IEnumerable<ScheduleModel>> GetMySchedulesAsync(DateTime scheduleDate);
        Task<ScheduleModel> GetScheduleAsync(int id);
        Task<ScheduleModel> InsertScheduleAsync(ScheduleModel schedule);
        Task<ScheduleModel> UpdateScheduleAsync(ScheduleModel shedule);
        void DeleteSchedule(int id);
    }
}
