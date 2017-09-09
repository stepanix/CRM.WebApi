using System;
using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface ITimeMileageRepository : IBaseRepository<TimeMileage>
    {
        Task<IEnumerable<TimeMileage>> GetTimeMileages();
        Task<TimeMileage> GetTimeMileage(int id);
        Task<IEnumerable<TimeMileage>> GetTimeMileage(DateTime dateFrom,DateTime dateTo);
        Task<TimeMileage> InsertTimeMileage(TimeMileage timeMileage);
        Task<TimeMileage> UpdateTimeMileage(TimeMileage timeMileage);
    }
}
