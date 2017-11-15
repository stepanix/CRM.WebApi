
using System;

namespace CRM.WebApi.Dto.Activities.In
{
    public class ActivityDtoIn
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public int PlaceId { get; set; }
        public string ActivityLog { get; set; }
        public string ActivityTypeId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}