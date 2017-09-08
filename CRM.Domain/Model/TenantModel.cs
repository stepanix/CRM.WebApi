using System;

namespace CRM.Domain.Model
{
    public class TenantModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
       
        public string WebSite { get; set; }
        
        public string ContactPerson { get; set; }
        
        public string ContactNumber { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
