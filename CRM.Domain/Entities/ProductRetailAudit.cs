﻿using CRM.Domain.Entity.Base;
using CRM.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class ProductRetailAudit : BaseEntity<int>
    {
        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        [ForeignKey("RetailAuditForm")]
        public int RetailAuditFormId { get; set; }
        public RetailAuditForm RetailAuditForm { get; set; }
        public string RetailAuditFormFieldValues { get; set; }
        public bool IsSaved { get; set; }
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
        public bool? Available { get; set; }
        public bool? Promoted { get; set; }
        public double? Price { get; set; }
        public double? StockLevel { get; set; }
        public string Note { get; set; }
        public string RepoId { get; set; }
    }
}
