﻿using CRM.Domain.Entity.Base;
using CRM.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Name { get; set; }
        public double Price { get; set; }
        public string EanCode { get; set; }
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
