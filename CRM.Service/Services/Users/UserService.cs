using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;

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
    }
}
