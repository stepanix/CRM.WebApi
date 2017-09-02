
namespace CRM.WebApi.Dto.Places.In
{
    public class PlaceDtoIn
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string ZipExtension { get; set; }

        public string Country { get; set; }

        public int? StatusId { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Phone { get; set; }

        public string CellPhone { get; set; }

        public string Comment { get; set; }
    }
}