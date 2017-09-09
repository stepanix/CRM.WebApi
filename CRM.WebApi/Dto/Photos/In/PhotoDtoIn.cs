

namespace CRM.WebApi.Dto.Photos.In
{
    public class PhotoDtoIn
    {
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public string Note { get; set; }
        public int PlaceId { get; set; }
        public int ScheduleId { get; set; }
    }
}