using System;

namespace CRM.Domain.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public int ScheduleId { get; set; }
        public ScheduleModel Schedule { get; set; }
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
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
