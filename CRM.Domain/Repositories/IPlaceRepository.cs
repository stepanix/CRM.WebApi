
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
        Task<Place> GetPlace(int id);
        Task<Place> InsertPlace(Place place);
        Task<Place> UpdatePlace(Place place);
        void DeletePlace(int id);
    }
}
