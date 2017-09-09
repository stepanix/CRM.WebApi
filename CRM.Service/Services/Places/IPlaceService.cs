using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Places
{
    public interface IPlaceService
    {
        Task<IEnumerable<PlaceModel>> GetPlacesAsync();
        Task<IEnumerable<PlaceModel>> GetPlacesAsync(DateTime dateFrom, DateTime dateTo);
        Task<PlaceModel> GetPlaceAsync(int id);
        Task<PlaceModel> InsertPlaceAsync(PlaceModel place);
        Task<PlaceModel> UpdatePlaceAsync(PlaceModel place);
        void DeletePlace(int id);
    }
}
