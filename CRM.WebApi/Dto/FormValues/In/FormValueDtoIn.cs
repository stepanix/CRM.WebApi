

namespace CRM.WebApi.Dto.FormValues.In
{
    public class FormValueDtoIn
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public int PlaceId { get; set; }
        public int FormId { get; set; }
        public string FormFieldValues { get; set; }
        public int ScheduleId { get; set; }
        public string PlaceRepoId { get; set; }
        public string ScheduleRepoId { get; set; }
    }
}