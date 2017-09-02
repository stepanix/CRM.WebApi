using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;


namespace CRM.EntityFramework.Repositories
{
    public class RepresentativePlaceRepository : ORMBaseRepository<RepresentativePlace, int>, IRepresentativePlaceRepository
    {
        
        public RepresentativePlaceRepository(DataContext context) : base(context)
        {
        }

        public void DeleteProductRetailAudit(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RepresentativePlace>> GetRepresentativeByPlaceId(int placeId)
        {
            return await GetDataContext()
                .RepresentativePlaces
                .Where(e => e.PlaceId == placeId)
                .Include(u => u.User)
                .ToListAsync();
        }

        public Task<RepresentativePlace> GetRepresentativePlace(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RepresentativePlace>> GetRepresentativePlaces()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RepresentativePlace> InsertRepresentativePlaceList(IEnumerable<RepresentativePlace> representativePlace)
        {
            GetDataContext().RepresentativePlaces.AddRange(representativePlace);
            return representativePlace;
        }

        public Task<RepresentativePlace> InsertRepresentativePlace(RepresentativePlace representativePlace)
        {
            throw new NotImplementedException();
        }

        public Task<RepresentativePlace> UpdateRepresentativePlace(RepresentativePlace representativePlace)
        {
            throw new NotImplementedException();
        }
    }
}
