using CRM.Domain.Entity.Base;
using CRM.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class OrderItem : BaseEntity<int>
    {
        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
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
