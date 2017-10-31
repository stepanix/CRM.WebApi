

using System;

namespace CRM.Domain.Model
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public string SyncId { get; set; }        
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public string CreatorUserId { get; set; }
        public string LastModifierUserId { get; set; }
        public UserModel LastModifierUser { get; set; }
        public UserModel CreatorUser { get; set; }
        public int TenantId { get; set; }
        public TenantModel Tenant { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
