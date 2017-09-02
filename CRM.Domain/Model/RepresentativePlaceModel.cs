

using System;

namespace CRM.Domain.Model
{
    public class RepresentativePlaceModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
