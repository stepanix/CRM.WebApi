using System;

namespace CRM.WebApi.Dto.TimeMileages.In
{
    public class TimeMileageDtoIn
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public string UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Duration { get; set; }
        public double Mileage { get; set; }
        public string RepoId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}