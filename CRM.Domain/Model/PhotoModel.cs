

using System;

namespace CRM.Domain.Model
{
    public class PhotoModel
    {
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public string Note { get; set; }
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public string CreatorUserId { get; set; }
        public string LastModifierUserId { get; set; }
        public int TenantId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ScheduleId { get; set; }
        public ScheduleModel Schedule { get; set; }
    }

}
