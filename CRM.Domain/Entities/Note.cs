using CRM.Domain.Entity.Base;
using CRM.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Note : BaseEntity<int>
    {
        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
       
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Description { get; set; }
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
        public string PlaceRepoId { get; set; }
        public string ScheduleRepoId { get; set; }
    }
}
