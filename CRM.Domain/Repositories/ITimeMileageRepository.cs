﻿using System;
using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface ITimeMileageRepository : IBaseRepository<TimeMileage>
    {
        Task<IEnumerable<TimeMileage>> GetTimeMileages();
        Task<TimeMileage> GetTimeMileage(int id);
        Task<TimeMileage> GetTimeMileage(DateTime dateCreated);
        Task<IEnumerable<TimeMileage>> GetTimeMileage(DateTime dateFrom,DateTime dateTo);
        Task<IEnumerable<TimeMileage>> GetTimeMileage(DateTime dateFrom, DateTime dateTo,string rep);
        Task<IEnumerable<TimeMileage>> GetTimeMileage(DateTime dateFrom, DateTime dateTo,int place);
        Task<IEnumerable<TimeMileage>> GetTimeMileage(DateTime dateFrom, DateTime dateTo,string rep, int place);
        Task<TimeMileage> InsertTimeMileage(TimeMileage timeMileage);
        IEnumerable<TimeMileage> InsertTimeMileageList(IEnumerable<TimeMileage> timeMileages);
        Task<TimeMileage> UpdateTimeMileage(TimeMileage timeMileage);
    }
}
