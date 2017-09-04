using AutoMapper;
using CRM.Domain.Entities;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using CRM.Domain.RequestIdentity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Statuses
{
    public class StatusService : IStatusService
    {

        IStatusRepository statusRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public StatusService(IMapper mapper, IStatusRepository statusRepository, IRequestIdentityProvider requestIdentityProvider, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.statusRepository = statusRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteStatus(int id)
        {
            statusRepository.Delete(id);
        }

        public async Task<StatusModel> GetStatusAsync(int id)
        {
            return mapper.Map<StatusModel>(await statusRepository.GetAsync(id));
        }

        public async Task<IEnumerable<StatusModel>> GetStatusesAsync()
        {
            return mapper.Map<IEnumerable<StatusModel>>(await statusRepository.GetStatuses());
        }

        public async Task<StatusModel> InsertStatusAsync(StatusModel status)
        {
            var user = await userRepository.GetUser();

            status.AddedDate = DateTime.Now;
            status.TenantId = user.TenantId;
            status.CreatorUserId = requestIdentityProvider.UserId;
            status.LastModifierUserId = requestIdentityProvider.UserId;
            var newStatus = await statusRepository.InsertAsync(mapper.Map<Status>(status));
            await statusRepository.SaveChangesAsync();
            return mapper.Map<StatusModel>(newStatus);
        }

        public async Task<StatusModel> UpdateStatusAsync(StatusModel status)
        {
            var user = await userRepository.GetUser();

            var statusForUpdate = await statusRepository.GetAsync(status.Id);

            statusForUpdate.ModifiedDate = DateTime.Now;
            statusForUpdate.Name = status.Name;
            statusForUpdate.TenantId = user.TenantId;
            statusForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            await statusRepository.SaveChangesAsync();
            return mapper.Map<StatusModel>(statusForUpdate);
        }

    }
}

