using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.RequestIdentity;
using CRM.Domain.Entities;

namespace CRM.Service.Services.VisitLogs
{
    public class VisitLogService : IVisitLogService
    {

        IVisitLogRepository visitLogRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public VisitLogService(IMapper mapper, IVisitLogRepository visitLogRepository, IRequestIdentityProvider requestIdentityProvider, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.visitLogRepository = visitLogRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteVisitLog(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VisitLogModel> GetVisitLogAsync(int scheduleid)
        {
            return mapper.Map<VisitLogModel>(await visitLogRepository.GetVisitLog(scheduleid));
        }

        public async Task<IEnumerable<VisitLogModel>> GetVisitLogsAsync()
        {
            return mapper.Map<IEnumerable<VisitLogModel>>(await visitLogRepository.GetVisitLogs());
        }

        public async Task<VisitLogModel> InsertVisitLogAsync(VisitLogModel visitlog)
        {
            var user = await userRepository.GetUser();

            visitlog.AddedDate = DateTime.Now;
            visitlog.TenantId = user.TenantId;
            visitlog.CreatorUserId = requestIdentityProvider.UserId;
            visitlog.LastModifierUserId = requestIdentityProvider.UserId;
            var newSchedule = await visitLogRepository.InsertAsync(mapper.Map<VisitLog>(visitlog));
            await visitLogRepository.SaveChangesAsync();
            return mapper.Map<VisitLogModel>(newSchedule);
        }

        public async Task<VisitLogModel> UpdateVisitLogAsync(VisitLogModel visitlog)
        {
            var visitLogForUpdate = await visitLogRepository.GetAsync(visitlog.Id);
            visitLogForUpdate.ModifiedDate = DateTime.Now;
            visitLogForUpdate.EndTime = DateTime.Now;
            visitLogForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            await visitLogRepository.SaveChangesAsync();
            return mapper.Map<VisitLogModel>(visitLogForUpdate);
        }

    }
}
