using CRM.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Form : BaseEntity<int>
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Title { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(2000)]
        public string Description { get; set; }
        public string Fields { get; set; }

    }
}
