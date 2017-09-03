

using System;

namespace CRM.Domain.Model
{
    public class FormValueModel
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public int FormId { get; set; }
        public FormModel Form { get; set; }
        public string FormFieldValues { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatorUserId { get; set; }
        public string LastModifierUserId { get; set; }
        public int TenantId { get; set; }
    }
}
