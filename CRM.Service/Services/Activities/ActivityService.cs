using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.RequestIdentity;
using CRM.Domain.Entities;

namespace CRM.Service.Services.Activities
{
    public class ActivityService : IActivityService
    {
        IActivityRepository activityRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public ActivityService(IMapper mapper, IActivityRepository activityRepository, IUserRepository userRepository, IRequestIdentityProvider requestIdentityProvider)
        {
            this.mapper = mapper;
            this.activityRepository = activityRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public async Task<IEnumerable<ActivityModel>> GetActivitiesAsync()
        {
            return mapper.Map<IEnumerable<ActivityModel>>(await activityRepository.GetAllAsync());
        }

        public async Task<IEnumerable<ActivityModel>> InsertActivityListAsync(IEnumerable<ActivityModel> activities)
        {
            var user = await userRepository.GetUser();

            List<ActivityModel> activityList = new List<ActivityModel>();

            foreach (var activity in activities)
            {
                var activityVar = new ActivityModel
                {
                    PlaceId = activity.PlaceId,
                    ActivityLog = activity.ActivityLog,
                    AddedDate = DateTime.Now,
                    TenantId = user.TenantId,
                    UserId = requestIdentityProvider.UserId
                };
                activityList.Add(activityVar);
            }
            var newActivityList = activityRepository.InsertActivityList(mapper.Map<IEnumerable<Activity>>(activityList));
            await activityRepository.SaveChangesAsync();
            return activityList; throw new NotImplementedException();
        }
    }

}
