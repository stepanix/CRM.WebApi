﻿
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.RequestIdentity;
using CRM.Domain.Entities;

namespace CRM.Service.Services.TimeMileages
{
    public class TimeMileageService : ITimeMileageService
    {
        ITimeMileageRepository timeMileageRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public TimeMileageService(IMapper mapper, ITimeMileageRepository timeMileageRepository, IRequestIdentityProvider requestIdentityProvider, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.timeMileageRepository = timeMileageRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public async Task<TimeMileageModel> GetTimeMileageAsync(int id)
        {
            return mapper.Map<TimeMileageModel>(await timeMileageRepository.GetAsync(id));
        }

        public async Task<IEnumerable<TimeMileageModel>> GetTimeMileageAsync(DateTime dateFrom, DateTime dateTo)
        {
            return mapper.Map<IEnumerable<TimeMileageModel>>(await timeMileageRepository.GetTimeMileage(dateFrom,dateTo));
        }

        public async Task<IEnumerable<TimeMileageModel>> GetTimeMileagesAsync()
        {
            return mapper.Map<IEnumerable<TimeMileageModel>>(await timeMileageRepository.GetTimeMileages());
        }

        public async Task<TimeMileageModel> InsertTimeMileageAsync(TimeMileageModel timeMileage)
        {
            var user = await userRepository.GetUser();

            timeMileage.AddedDate = DateTime.Now;
            timeMileage.TenantId = user.TenantId;
            timeMileage.CreatorUserId = requestIdentityProvider.UserId;
            timeMileage.LastModifierUserId = requestIdentityProvider.UserId;
            var newTimeMileage = await timeMileageRepository.InsertAsync(mapper.Map<TimeMileage>(timeMileage));
            await timeMileageRepository.SaveChangesAsync();
            return mapper.Map<TimeMileageModel>(newTimeMileage);
        }

        public async Task<TimeMileageModel> UpdateTimeMileageAsync(TimeMileageModel timeMileage)
        {
            var user = await userRepository.GetUser();

            var timeMileageForUpdate = await timeMileageRepository.GetAsync(timeMileage.Id);

            TimeSpan duration = DateTime.Now.Subtract(timeMileage.StartTime);

            timeMileageForUpdate.ModifiedDate = DateTime.Now;
            timeMileageForUpdate.PlaceId = timeMileage.PlaceId;
            timeMileageForUpdate.EndTime = timeMileage.EndTime;
            timeMileageForUpdate.Duration = duration.TotalDays;
            timeMileageForUpdate.TenantId = user.TenantId;
            timeMileageForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            await timeMileageRepository.SaveChangesAsync();
            return mapper.Map<TimeMileageModel>(timeMileageForUpdate);
        }

        public async Task<IEnumerable<TimeMileageModel>> GetTimeMileageAsync(DateTime dateFrom, DateTime dateTo, string rep)
        {
            return mapper.Map<IEnumerable<TimeMileageModel>>(await timeMileageRepository.GetTimeMileage(dateFrom, dateTo,rep));
        }
    }
}
