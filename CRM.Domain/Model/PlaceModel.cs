

using System;

namespace CRM.Domain.Model
{
    public class PlaceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public int? StatusId { get; set; }
        public StatusModel Status { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Comment { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
