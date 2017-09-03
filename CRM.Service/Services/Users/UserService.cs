using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Identity;

namespace CRM.Service.Services.Users
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        IMapper mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<UserModel>> GetUnAssignedRepsByPlaceIdAsync(int placeId)
        {
            return mapper.Map<IEnumerable<UserModel>>(await userRepository.GetUnAssignedRepsByPlaceId(placeId));
        }

        public async Task<UserModel> GetUserAsync(string userId)
        {
            return mapper.Map<UserModel>(await userRepository.GetUser(userId));
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return mapper.Map<IEnumerable<UserModel>>(await userRepository.GetUsers());
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
             var userForUpdate = await userRepository.UpdateUser(mapper.Map<User>(user));
            return mapper.Map<UserModel>(userForUpdate);
        }
    }
}
