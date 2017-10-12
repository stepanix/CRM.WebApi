using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Places
{
    public interface IPlaceService
    {
        Task<IEnumerable<PlaceModel>> GetPlacesAsync();
        Task<IEnumerable<PlaceModel>> GetPlacesAsync(DateTime dateFrom, DateTime dateTo);
        Task<IEnumerable<PlaceModel>> GetPlacesAsync(DateTime dateFrom, DateTime dateTo,string rep);
        Task<IEnumerable<PlaceModel>> GetPlacesAsync(DateTime dateFrom, DateTime dateTo,int place);
        Task<IEnumerable<PlaceModel>> GetPlacesAsync(DateTime dateFrom, DateTime dateTo,string rep, int place);
        Task<PlaceModel> GetPlaceAsync(int id);
        Task<PlaceModel> InsertPlaceAsync(PlaceModel place);
        Task<IEnumerable<PlaceModel>> InsertPlaceListAsync(IEnumerable<PlaceModel> place);
        Task<PlaceModel> UpdatePlaceAsync(PlaceModel place);
        void DeletePlace(int id);
    }
}
