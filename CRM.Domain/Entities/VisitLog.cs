using CRM.Domain.Entity.Base;
using CRM.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class VisitLog : BaseEntity<int>
    {
        [Required]
        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
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
    }
}
