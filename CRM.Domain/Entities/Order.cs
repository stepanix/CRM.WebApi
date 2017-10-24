using CRM.Domain.Entity.Base;
using CRM.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        [Required]
        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        [Required]
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public double DiscountRate { get; set; }
        public double DiscountAmount { get; set; }
        public double TaxRate { get; set; }
        public double TaxAmount { get; set; }
        public double TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? DueDays { get; set; }
        public DateTime? DueDate { get; set; }
        public string Note { get; set; }
        public string signature { get; set; }
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
