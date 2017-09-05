using CRM.Domain.Entity.Base;
using CRM.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Schedule : BaseEntity<int>
    {
        [Required]
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime VisitDate { get; set; }
       
        [Column(TypeName = "DateTime")]
        public DateTime? VisitTime { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(1000)]
        public string VisitNote { get; set; }
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
        public bool IsRepeat { get; set; }
        public int? RepeatCycle { get; set; }
        public bool IsVisited { get; set; }
        public bool IsScheduled { get; set; }
    }
}
