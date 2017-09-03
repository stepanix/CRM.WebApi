

using CRM.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUnAssignedRepsByPlaceIdAsync(int placeId);
        Task<UserModel> GetUserAsync(string userId);
        Task<IEnumerable<UserModel>> GetUsersAsync();
        Task<UserModel> UpdateUserAsync(UserModel user);
    }
}
