using AutoMapper;
using CRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Entities;

namespace CRM.Service.Services.Schedules
{
    public class ScheduleService : IScheduleService
    {
        IScheduleRepository scheduleRepository;
        IMapper mapper;

        public ScheduleService(IMapper mapper, IScheduleRepository scheduleRepository)
        {
            this.mapper = mapper;
            this.scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<ScheduleModel>> GetSchedulesAsync()
        {
            return mapper.Map<IEnumerable<ScheduleModel>>(await scheduleRepository.GetAllAsync());
        }

        public async Task<ScheduleModel> GetScheduleAsync(int id)
        {
            return mapper.Map<ScheduleModel>(await scheduleRepository.GetAsync(id));
        }

        public async Task<ScheduleModel> InsertScheduleAsync(ScheduleModel schedule)
        {
            schedule.AddedDate = DateTime.Now;
            var newSchedule = await scheduleRepository.InsertAsync(mapper.Map<Schedule>(schedule));
            await scheduleRepository.SaveChangesAsync();
            return mapper.Map<ScheduleModel>(newSchedule);
        }

        public async Task<ScheduleModel> UpdateScheduleAsync(ScheduleModel shedule)
        {
            var scheduleForUpdate = await scheduleRepository.GetAsync(shedule.Id);
            scheduleForUpdate.ModifiedDate = DateTime.Now;
            scheduleForUpdate.PlaceId = shedule.PlaceId;
            scheduleForUpdate.Recurring = shedule.Recurring;
            scheduleForUpdate.VisitDate = shedule.VisitDate;
            scheduleForUpdate.VisitNote = shedule.VisitNote;
            scheduleForUpdate.VisitTime = shedule.VisitTime;

            await scheduleRepository.SaveChangesAsync();
            return mapper.Map<ScheduleModel>(scheduleForUpdate);
        }

        public void DeleteSchedule(int id)
        {
            scheduleRepository.Delete(id);
        }

    }
}
