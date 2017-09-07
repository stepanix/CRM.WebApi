using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IScheduleRepository : IBaseRepository<Schedule>
    {
        Task<IEnumerable<Schedule>> GetSchedules(DateTime date);
        Task<IEnumerable<Schedule>> GetMissedSchedules();
        Task<IEnumerable<Schedule>> GetSchedules(bool isVisited,bool isScheduled,DateTime date);
        Task<IEnumerable<Schedule>> GetMySchedules(DateTime date);
        Task<Schedule> GetSchedule(int id);
        Task<Schedule> InsertSchedule(Schedule schedule);
        Task<Schedule> UpdateSchedule(Schedule schedule);
        void DeleteSchedule(int id);
    }
}
