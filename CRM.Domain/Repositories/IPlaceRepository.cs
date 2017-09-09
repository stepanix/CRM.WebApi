
using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IPlaceRepository : IBaseRepository<Place>
    {
        Task<IEnumerable<Place>> GetPlaces();
        Task<IEnumerable<Place>> GetPlaces(DateTime dateFrom, DateTime dateTo);
        Task<IEnumerable<Place>> GetPlaces(DateTime dateFrom, DateTime dateTo, string rep, int place);
        Task<IEnumerable<Place>> GetPlaces(DateTime dateFrom, DateTime dateTo, string rep);
        Task<IEnumerable<Place>> GetPlaces(DateTime dateFrom, DateTime dateTo, int place);
        Task<Place> GetPlace(int id);
        Task<Place> InsertPlace(Place place);
        Task<Place> UpdatePlace(Place place);
        void DeletePlace(int id);
    }
}
