using CRM.Domain.Entity.Base;
using CRM.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Activity : BaseEntity<int>
    {
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public string ActivityLog { get; set; }
        [Required]
        [ForeignKey("Tenant")]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
