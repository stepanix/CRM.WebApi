using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using CRM.Domain.RequestIdentity;

namespace CRM.EntityFramework.Repositories
{
    public class PlaceRepository : ORMBaseRepository<Place, int>, IPlaceRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public PlaceRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeletePlace(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Place> GetPlace(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Places
               .Where(t => t.TenantId == user.TenantId)
               .ToListAsync();
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
