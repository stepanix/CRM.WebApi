using AutoMapper;
using CRM.Domain.Entities;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Statuses
{
    public class StatusService : IStatusService
    {

        IStatusRepository statusRepository;
        IMapper mapper;

        public StatusService(IMapper mapper, IStatusRepository statusRepository)
        {
            this.mapper = mapper;
            this.statusRepository = statusRepository;
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
            return mapper.Map<IEnumerable<StatusModel>>(await statusRepository.GetAllAsync());
        }

        public async Task<StatusModel> InsertStatusAsync(StatusModel status)
        {
            status.AddedDate = DateTime.Now;
            var newStatus = await statusRepository.InsertAsync(mapper.Map<Status>(status));
            await statusRepository.SaveChangesAsync();
            return mapper.Map<StatusModel>(newStatus);
        }

        public async Task<StatusModel> UpdateStatusAsync(StatusModel status)
        {
            var statusForUpdate = await statusRepository.GetAsync(status.Id);
            statusForUpdate.ModifiedDate = DateTime.Now;
            statusForUpdate.Name = status.Name;
            await statusRepository.SaveChangesAsync();
            return mapper.Map<StatusModel>(statusForUpdate);
        }

    }
}

