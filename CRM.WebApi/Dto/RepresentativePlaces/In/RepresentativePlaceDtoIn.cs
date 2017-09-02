using System;


namespace CRM.WebApi.Dto.RepresentativePlaces.In
{
    public class RepresentativePlaceDtoIn
    {
        public int Id { get; set; }
        public string UserId { get; set; }       
        public int PlaceId { get; set; }       
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}