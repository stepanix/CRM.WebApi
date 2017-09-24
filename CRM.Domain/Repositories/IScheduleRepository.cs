using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IScheduleRepository : IBaseRepository<Schedule>
    {
        Task<IEnumerable<Schedule>> GetSchedules();
        Task<IEnumerable<Schedule>> GetMissedSchedules();
        Task<IEnumerable<Schedule>> GetSchedules(bool isVisited,bool isScheduled,bool isUnScheduled,bool isMissed);
        Task<IEnumerable<Schedule>> GetSchedules(DateTime dateFrom, DateTime dateTo);
        Task<IEnumerable<Schedule>> GetSchedules(DateTime dateFrom, DateTime dateTo,string rep);
        Task<IEnumerable<Schedule>> GetSchedules(DateTime dateFrom, DateTime dateTo, int place);
        Task<IEnumerable<Schedule>> GetSchedules(DateTime dateFrom, DateTime dateTo,string rep,int place);
        Task<IEnumerable<Schedule>> GetMySchedules(DateTime scheduleDate);
        Task<Schedule> GetSchedule(int id);
        Task<Schedule> InsertSchedule(Schedule schedule);
        IEnumerable<Schedule> InsertScheduleList(IEnumerable<Schedule> schedules);
        Task<Schedule> UpdateSchedule(Schedule schedule);
        void DeleteSchedule(int id);
    }
}
