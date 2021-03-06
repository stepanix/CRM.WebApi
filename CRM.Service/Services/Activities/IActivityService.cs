﻿using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Activities
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityModel>> GetActivitiesAsync();
        Task<IEnumerable<ActivityModel>> GetActivitiesAsync(string userId);
        Task<IEnumerable<ActivityModel>> InsertActivityListAsync(IEnumerable<ActivityModel> activities);
        Task<ActivityModel> GetActivitiesAsync(string userId, DateTime dateFrom, DateTime dateTo, int placeId);
        Task<IEnumerable<ActivityModel>> GetActivitiesAsync(string userId, DateTime dateFrom, DateTime dateTo);
        Task<IEnumerable<ActivityModel>> GetActivitiesAsync(DateTime dateFrom, DateTime dateTo);
    }
}
