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
        IFormValueRepository formValueRepository;
        INoteRepository noteRepository;
        IOrderRepository orderRepository;
        IProductRetailAuditRepository productRetailAuditRepository;
        IPhotoRepository photoRepository;

        public ActivityService(IPhotoRepository photoRepository,IProductRetailAuditRepository productRetailAuditRepository,IOrderRepository orderRepository,INoteRepository noteRepository,IFormValueRepository formValueRepository,IMapper mapper, IActivityRepository activityRepository, IUserRepository userRepository, IRequestIdentityProvider requestIdentityProvider)
        {
            this.mapper = mapper;
            this.activityRepository = activityRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
            this.photoRepository = photoRepository;
            this.productRetailAuditRepository = productRetailAuditRepository;
            this.orderRepository = orderRepository;
            this.noteRepository = noteRepository;
            this.formValueRepository = formValueRepository;
        }

        public async Task<IEnumerable<ActivityModel>> GetActivitiesAsync()
        {
            return mapper.Map<IEnumerable<ActivityModel>>(await activityRepository.GetAllAsync());
        }

        public async Task<IEnumerable<ActivityModel>> InsertActivityListAsync(IEnumerable<ActivityModel> activities)
        {
            var user = await userRepository.GetUser();

            IList<ActivityModel> activityList = new List<ActivityModel>();

            foreach (var activity in activities)
            {
                var activityVar = new ActivityModel
                {
                    SyncId = activity.SyncId,
                    PlaceId = activity.PlaceId,
                    ActivityLog = activity.ActivityLog,
                    ActivityTypeId = activity.ActivityTypeId,
                    DateCreated = activity.DateCreated,
                    AddedDate = DateTime.Now,
                    TenantId = user.TenantId,
                    UserId = requestIdentityProvider.UserId
                };
                activityList.Add(activityVar);
            }
            var newActivityList = activityRepository.InsertActivityList(mapper.Map<IEnumerable<Activity>>(activityList));
            await activityRepository.SaveChangesAsync();
            return activityList;
        }

        public async Task<IEnumerable<ActivityModel>> GetActivitiesAsync(string userId, DateTime dateFrom, DateTime dateTo, int placeId)
        {
            return mapper.Map<IEnumerable<ActivityModel>>(await activityRepository.GetActivities(userId, dateFrom, dateTo, placeId));
        }

        public Task<IEnumerable<ActivityModel>> GetActivitiesAsync(string userId, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActivityModel>> GetActivitiesAsync(string userId)
        {
            IList<ActivityModel> lstActivities = new List<ActivityModel>();
            var allActivities = await activityRepository.GetActivities(userId);

            FormValueModel formValue = null;
            NoteModel note = null;
            OrderModel orders = null;
            PhotoModel photo = null;
            ProductRetailAuditModel productRetailAudit = null;

            foreach (var activity in allActivities)
            {
                formValue = mapper.Map<FormValueModel>(await formValueRepository.GetFormValue(activity.ActivityTypeId));
                note = mapper.Map<NoteModel>(await noteRepository.GetNote(activity.ActivityTypeId));
                orders = mapper.Map<OrderModel>(await orderRepository.GetOrder(activity.ActivityTypeId));
                photo = mapper.Map<PhotoModel>(await photoRepository.GetPhoto(activity.ActivityTypeId));
                productRetailAudit = mapper.Map<ProductRetailAuditModel>(await productRetailAuditRepository.GetProductRetailAudit(activity.ActivityTypeId));

                var activityVar = new ActivityModel
                {
                    Id = activity.Id,
                    PlaceId = activity.PlaceId,
                    ActivityLog = activity.ActivityLog,
                    ActivityTypeId = activity.ActivityTypeId,
                    DateCreated = activity.DateCreated,
                    FormValue = formValue,
                    Note = note,
                    Order = orders,
                    Photo = photo,
                    ProductRetailAudit = productRetailAudit,
                    UserId = requestIdentityProvider.UserId
                };
                lstActivities.Add(activityVar);
            }
            return lstActivities;
        }

        public async Task<IEnumerable<ActivityModel>> GetActivitiesAsync(DateTime dateFrom, DateTime dateTo)
        {
            return mapper.Map<IEnumerable<ActivityModel>>(await activityRepository.GetActivities(dateFrom, dateTo));
        }
    }

}
