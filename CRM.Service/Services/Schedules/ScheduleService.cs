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

        public async Task<IEnumerable<ScheduleModel>> GetSchedulesAsync()
        {
            return mapper.Map<IEnumerable<ScheduleModel>>(await scheduleRepository.GetSchedules());
        }

        public async Task<ScheduleModel> GetScheduleAsync(int id)
        {
            return mapper.Map<ScheduleModel>(await scheduleRepository.GetAsync(id));
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
            scheduleForUpdate.Recurring = shedule.Recurring;
            scheduleForUpdate.VisitDate = shedule.VisitDate;
            scheduleForUpdate.VisitNote = shedule.VisitNote;
            scheduleForUpdate.VisitTime = shedule.VisitTime;

            scheduleForUpdate.TenantId = user.TenantId;
            scheduleForUpdate.LastModifierUserId = requestIdentityProvider.UserId;

            await scheduleRepository.SaveChangesAsync();
            return mapper.Map<ScheduleModel>(scheduleForUpdate);
        }

        public void DeleteSchedule(int id)
        {
            scheduleRepository.Delete(id);
        }

    }
}
