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
        IOrderItemRepository orderItemRepository;
        IProductRetailAuditRepository productRetailAuditRepository;
        IPhotoRepository photoRepository;
        IScheduleRepository scheduleRepository;

        public ActivityService(IOrderItemRepository orderItemRepository,
            IScheduleRepository scheduleRepository,
            IPhotoRepository photoRepository,
            IProductRetailAuditRepository productRetailAuditRepository,
            IOrderRepository orderRepository,
            INoteRepository noteRepository,
            IFormValueRepository formValueRepository,
            IMapper mapper, 
            IActivityRepository activityRepository, 
            IUserRepository userRepository, 
            IRequestIdentityProvider requestIdentityProvider)
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
            this.scheduleRepository = scheduleRepository;
            this.orderItemRepository = orderItemRepository;
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

        public async Task<ActivityModel> GetActivitiesAsync(string userId, DateTime dateFrom, DateTime dateTo, int placeId)
        {
            var allActivities = await activityRepository.GetActivities(userId, dateFrom, dateTo, placeId);

            int formCount = 0;
            int noteCount = 0;
            int retailAuditCount = 0;
            int orderCount = 0;
            int photoCount = 0;
            ScheduleSummaryModel summarySchedule = null;
            string totalOrder = "0";

            summarySchedule = await GetScheduleSummary(userId, dateFrom, dateTo, placeId);

            totalOrder = await GetOrderTotal(userId, dateFrom, dateTo, placeId);

            foreach (var activity in allActivities)
            {
                if (activity.ActivityLog == "Forms")
                    formCount += 1;

                if (activity.ActivityLog == "Notes")
                    noteCount += 1;

                if (activity.ActivityLog == "Product Retail Audit")
                    retailAuditCount += 1;

                if (activity.ActivityLog == "Orders")
                    orderCount += 1;

                if (activity.ActivityLog == "Photos")
                    photoCount += 1;
            }

            var activityVar = new ActivityModel
            {
                FormCount = formCount,
                NoteCount = noteCount,
                RetailAuditCount = retailAuditCount,
                OrderCount = orderCount,
                PhotoCount = photoCount,
                TotalVisitCount = summarySchedule.TotalVisitCount,
                MissedVisitCount = summarySchedule.MissedCount,
                UnScheduledVisitCount = summarySchedule.UnscheduledCount,
                ScheduledVisitCount = summarySchedule.ScheduledCount,
                VisitCount = summarySchedule.VisitCount,
                UserId = userId,
                OrderTotal = totalOrder
            };
            return activityVar;
        }

        private async Task<ScheduleSummaryModel> GetScheduleSummary(string userId, DateTime dateFrom, DateTime dateTo, int placeId)
        {
            var scheduleList = await scheduleRepository.GetSchedules(dateFrom, dateTo, userId, placeId);
            int totalVisitCount = 0;
            int scheduledVisitCount = 0;
            int visitCount = 0;
            int unScheduledVisitCount = 0;
            int missedVisitCount = 0;

            foreach (var schedule in scheduleList)
            {
                if (schedule.IsVisited == true)
                    totalVisitCount += 1;

                if (schedule.IsScheduled == true)
                    scheduledVisitCount += 1;

                if (schedule.IsVisited == true && schedule.IsScheduled == true)
                    visitCount += 1;

                if (schedule.IsUnScheduled == true)
                    unScheduledVisitCount += 1;

                if (schedule.IsMissed == true)
                    missedVisitCount += 1;
            }

            var scheduleSummary = new ScheduleSummaryModel
            {
                MissedCount = missedVisitCount,
                ScheduledCount = scheduledVisitCount,
                TotalVisitCount = totalVisitCount,
                UnscheduledCount = unScheduledVisitCount,
                VisitCount = visitCount
            };
            return scheduleSummary;
        }

        private async Task<string> GetOrderTotal(string rep, DateTime dateFrom, DateTime dateTo,  int place)
        {
            double totalOrder = 0;
            var orders = await orderRepository.GetOrders(dateFrom, dateTo, rep, place);
            foreach (var order in orders)
            {
                totalOrder += order.TotalAmount;
            }
           return string.Format("{0:#,0.####}", totalOrder);
        }

        public Task<IEnumerable<ActivityModel>> GetActivitiesAsync(string userId, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActivityModel>> GetActivitiesAsync(string userId)
        {
            IList<ActivityModel> lstActivities = new List<ActivityModel>();
            var allActivities =  mapper.Map<IEnumerable<ActivityModel>>(await activityRepository.GetActivities(userId));

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
                    UserId = requestIdentityProvider.UserId,
                    User = activity.User,
                    Place = activity.Place,
                    Submitted = 4
                };
                lstActivities.Add(activityVar);
            }
            return lstActivities;
        }

        public async Task<IEnumerable<ActivityModel>> GetActivitiesAsync(DateTime dateFrom, DateTime dateTo)
        {
            IList<ActivityModel> lstActivities = new List<ActivityModel>();
            var allActivities = mapper.Map<IEnumerable<ActivityModel>>(await activityRepository.GetActivities(dateFrom, dateTo));
            //var allActivities = await activityRepository.GetActivities(dateFrom, dateTo);

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
                    UserId = requestIdentityProvider.UserId,
                    User = activity.User,
                    Place = activity.Place,
                    Submitted = 4
                };
                lstActivities.Add(activityVar);
            }
            return lstActivities;
        }
    }

}
