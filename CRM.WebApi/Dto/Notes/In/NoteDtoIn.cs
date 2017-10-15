

namespace CRM.WebApi.Dto.Notes.In
{
    public class NoteDtoIn
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public int PlaceId { get; set; }
        public string Description { get; set; }
        public int ScheduleId { get; set; }
    }
}