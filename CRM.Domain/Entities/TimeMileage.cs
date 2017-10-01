

using CRM.Domain.Entity.Base;
using CRM.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class TimeMileage : BaseEntity<int>
    {
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double Duration { get; set; }
        public double Mileage { get; set; }
        [Required]
        [ForeignKey("CreatorUser")]
        public string CreatorUserId { get; set; }
        [Required]
        [ForeignKey("LastModifierUser")]
        public string LastModifierUserId { get; set; }
        public User LastModifierUser { get; set; }
        public User CreatorUser { get; set; }
        [Required]
        [ForeignKey("Tenant")]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string RepoId { get; set; }
    }
}
