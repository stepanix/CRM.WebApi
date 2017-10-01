

using System;

namespace CRM.Domain.Model
{
    public class NoteModel
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatorUserId { get; set; }
        public string LastModifierUserId { get; set; }
        public int TenantId { get; set; }
        public int ScheduleId { get; set; }
        public ScheduleModel Schedule { get; set; }
        public string PlaceRepoId { get; set; }
        public string ScheduleRepoId { get; set; }
    }
}
