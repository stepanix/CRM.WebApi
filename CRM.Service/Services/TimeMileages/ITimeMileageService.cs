using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.TimeMileages
{
    public interface ITimeMileageService
    {
        Task<IEnumerable<TimeMileageModel>> GetTimeMileagesAsync();
        Task<TimeMileageModel> GetTimeMileageAsync(int id);
        Task<IEnumerable<TimeMileageModel>> GetTimeMileageAsync(DateTime dateFrom, DateTime dateTo);
        Task<IEnumerable<TimeMileageModel>> GetTimeMileageAsync(DateTime dateFrom, DateTime dateTo,string rep);
        Task<TimeMileageModel> InsertTimeMileageAsync(TimeMileageModel timeMileage);
        Task<TimeMileageModel> UpdateTimeMileageAsync(TimeMileageModel timeMileage);
    }
}
