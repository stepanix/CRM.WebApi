using CRM.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class FormValue : BaseEntity<int>
    {
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        [ForeignKey("Form")]
        public int FormId { get; set; }
        public Form Form { get; set; }
        public string FormFieldValues { get; set; }
    }
}
