using CRM.Domain.Repositories;
using CRM.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using CRM.Domain.RequestIdentity;

namespace CRM.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext context;
        IRequestIdentityProvider requestIdentityProvider;

        public UserRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider)
        {
            this.context = context;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public async Task<IEnumerable<User>> GetUnAssignedRepsByPlaceId(int placeId)
        {
            return await context
                .Users
                .Where(user => !context.RepresentativePlaces.Any(f => f.UserId == user.Id && f.PlaceId==placeId && f.IsDeleted==false))
                .ToListAsync();
        }

        public async Task<User> GetUser()
        {
            return await context
                .Users
                .Where(user => user.Id == requestIdentityProvider.UserId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context
                .Users
                .ToListAsync();
        }
    }
}
