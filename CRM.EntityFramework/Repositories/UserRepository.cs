using CRM.Domain.Repositories;
using CRM.Domain.Identity;
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
            var user = await context.Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await context
                .Users
                .Where(u => !context.RepresentativePlaces.Any(f => f.UserId == u.Id 
                && f.PlaceId==placeId && f.IsDeleted==false) 
                && u.TenantId == user.TenantId)
                .ToListAsync();
        }

        public async Task<User> GetUser()
        {
            return await context
                .Users
                .Where(user => user.Id == requestIdentityProvider.UserId)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUser(string userId)
        {
            return await context
                .Users
                .Where(user => user.Id == userId)
                .Include(t => t.Tenant)
                .Include(r=> r.Roles)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var user = await context.Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();

            return await context
                .Users
                .Where(t => t.TenantId == user.TenantId)
                .Include(t => t.Tenant)
                .ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var userForUpdate = await context
                .Users
                .Where(u => u.Id == user.Id)
                .FirstOrDefaultAsync();

            userForUpdate.FirstName = user.FirstName;
            userForUpdate.Surname = user.Surname;
            userForUpdate.IsActive = user.IsActive;
            userForUpdate.TenantId = user.TenantId;
            await context.SaveChangesAsync();
            return user;
        }
    }
}
