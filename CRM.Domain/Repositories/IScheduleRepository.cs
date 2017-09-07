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
        Task<IEnumerable<Schedule>> GetMySchedules();
        Task<Schedule> GetSchedule(int id);
        Task<Schedule> InsertSchedule(Schedule schedule);
        Task<Schedule> UpdateSchedule(Schedule schedule);
        void DeleteSchedule(int id);
    }
}
