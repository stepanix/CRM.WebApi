using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories
{
    public class PlaceRepository : ORMBaseRepository<Place, int>, IPlaceRepository
    {
        public PlaceRepository(DataContext context) : base(context)
        {
        }

        public void DeletePlace(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Place> GetPlace(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Place>> GetPlaces()
        {
            throw new NotImplementedException();
        }

        public Task<Place> InsertPlace(Place place)
        {
            throw new NotImplementedException();
        }

        public Task<Place> UpdatePlace(Place place)
        {
            throw new NotImplementedException();
        }
    }
}
