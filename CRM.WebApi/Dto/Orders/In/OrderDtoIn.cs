using System;

namespace CRM.WebApi.Dto.Orders.In
{
    public class OrderDtoIn
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public int ScheduleId { get; set; }       
        public int PlaceId { get; set; }        
        public int ProductId { get; set; }
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
    }
}