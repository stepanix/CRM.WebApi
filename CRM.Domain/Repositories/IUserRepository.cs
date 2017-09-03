

using CRM.Domain.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(string userId);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUnAssignedRepsByPlaceId(int placeId);
        Task<User> GetUser();
        Task<User> UpdateUser(User user);
    }

}
