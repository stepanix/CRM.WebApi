
namespace CRM.WebApi.Dto.OrderItems.In
{
    public class OrderItemDtoIn
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public int OrderId { get; set; }        
        public int ProductId { get; set; }       
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}