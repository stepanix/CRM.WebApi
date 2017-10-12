using AutoMapper;
using CRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Entities;
using CRM.Domain.RequestIdentity;

namespace CRM.Service.Services.Schedules
{
    public class ScheduleService : IScheduleService
    {
        IScheduleRepository scheduleRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public ScheduleService(IMapper mapper, IScheduleRepository scheduleRepository, IRequestIdentityProvider requestIdentityProvider, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.scheduleRepository = scheduleRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public async Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(bool isVisited, bool isScheduled, bool isUnScheduled, bool isMissed)
        {
            return mapper.Map<IEnumerable<ScheduleModel>>(await scheduleRepository.GetSchedules(isVisited, isScheduled, isUnScheduled, isMissed));
        }

        public async Task<IEnumerable<ScheduleModel>> GetSchedulesAsync()
        {
            return mapper.Map<IEnumerable<ScheduleModel>>(await scheduleRepository.GetSchedules());
        }

        public async Task<ScheduleModel> GetScheduleAsync(int id)
        {
            return mapper.Map<ScheduleModel>(await scheduleRepository.GetSchedule(id));
        }

        public async Task<ScheduleModel> InsertScheduleAsync(ScheduleModel schedule)
        {
            var user = await userRepository.GetUser();

            schedule.AddedDate = DateTime.Now;
            schedule.TenantId = user.TenantId;
            schedule.CreatorUserId = requestIdentityProvider.UserId;
            schedule.LastModifierUserId = requestIdentityProvider.UserId;
            var newSchedule = await scheduleRepository.InsertAsync(mapper.Map<Schedule>(schedule));
            await scheduleRepository.SaveChangesAsync();
            return mapper.Map<ScheduleModel>(newSchedule);
        }

        public async Task<ScheduleModel> UpdateScheduleAsync(ScheduleModel shedule)
        {
            var user = await userRepository.GetUser();
            var scheduleForUpdate = await scheduleRepository.GetAsync(shedule.Id);

            scheduleForUpdate.ModifiedDate = DateTime.Now;
            scheduleForUpdate.PlaceId = shedule.PlaceId;
            scheduleForUpdate.IsRepeat = shedule.IsRepeat;
            scheduleForUpdate.VisitDate = shedule.VisitDate;
            scheduleForUpdate.VisitNote = shedule.VisitNote;
            scheduleForUpdate.VisitTime = shedule.VisitTime;
            scheduleForUpdate.RepeatCycle = shedule.RepeatCycle;
            scheduleForUpdate.IsVisited = shedule.IsVisited;
            scheduleForUpdate.TenantId = user.TenantId;
            scheduleForUpdate.IsScheduled = shedule.IsScheduled;
            scheduleForUpdate.IsMissed = shedule.IsMissed;
            scheduleForUpdate.IsUnScheduled = shedule.IsUnScheduled;
            scheduleForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            scheduleForUpdate.VisitStatus = shedule.VisitStatus;
            scheduleForUpdate.CheckInTime = shedule.CheckInTime;
            scheduleForUpdate.CheckOutTime = shedule.CheckOutTime;
            await scheduleRepository.SaveChangesAsync();
            return mapper.Map<ScheduleModel>(scheduleForUpdate);
        }

        public void DeleteSchedule(int id)
        {
            scheduleRepository.Delete(id);
        }

        public async Task<IEnumerable<ScheduleModel>> GetMySchedulesAsync(DateTime scheduleDate)
        {
            return mapper.Map<IEnumerable<ScheduleModel>>(await scheduleRepository.GetMySchedules(scheduleDate));
        }

        public async Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(DateTime dateFrom, DateTime dateTo)
        {
            return mapper.Map<IEnumerable<ScheduleModel>>(await scheduleRepository.GetSchedules(dateFrom,dateTo));
        }

        public async Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(DateTime dateFrom, DateTime dateTo, string rep)
        {
            return mapper.Map<IEnumerable<ScheduleModel>>(await scheduleRepository.GetSchedules(dateFrom, dateTo, rep));
        }

        public async Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(DateTime dateFrom, DateTime dateTo, int place)
        {
            return mapper.Map<IEnumerable<ScheduleModel>>(await scheduleRepository.GetSchedules(dateFrom, dateTo, place));
        }

        public async Task<IEnumerable<ScheduleModel>> GetSchedulesAsync(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            return mapper.Map<IEnumerable<ScheduleModel>>(await scheduleRepository.GetSchedules(dateFrom, dateTo, rep, place));
        }

        
        public async Task<IEnumerable<ScheduleModel>> InsertScheduleListAsync(IEnumerable<ScheduleModel> schedules)
        {
            var user = await userRepository.GetUser();

            List<ScheduleModel> scheduleList = new List<ScheduleModel>();

            foreach (var schedule in schedules)
            {
                if(schedule.Id == 0)
                {
                    var scheduleVar = new ScheduleModel
                    {
                        RepoId = schedule.RepoId,
                        SyncId = schedule.SyncId,
                        PlaceId = schedule.PlaceId,
                        CheckInTime = schedule.CheckInTime,
                        CheckOutTime = schedule.CheckOutTime,
                        IsMissed = schedule.IsMissed,
                        IsRepeat = schedule.IsRepeat,
                        IsUnScheduled = schedule.IsUnScheduled,
                        IsVisited = schedule.IsVisited,
                        RepeatCycle = schedule.RepeatCycle,
                        UserId = schedule.UserId,
                        VisitDate = schedule.VisitDate,
                        VisitNote = schedule.VisitNote,
                        VisitTime = schedule.VisitTime,
                        VisitStatus = schedule.VisitStatus,
                        IsScheduled = schedule.IsScheduled,
                        AddedDate = DateTime.Now,
                        TenantId = user.TenantId,
                        CreatorUserId = requestIdentityProvider.UserId,
                        LastModifierUserId = requestIdentityProvider.UserId
                    };
                    scheduleList.Add(scheduleVar);
                    var newScheduleList = scheduleRepository.InsertAsync(mapper.Map<Schedule>(scheduleVar));
                    await scheduleRepository.SaveChangesAsync();
                }
                else
                {
                    scheduleList.Add(schedule);
                    await UpdateScheduleAsync(schedule);
                }
            }
            return scheduleList;
        }
    }

    


}
