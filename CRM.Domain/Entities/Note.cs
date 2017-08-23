using CRM.Domain.Entity.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Note : BaseEntity<int>
    {
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
       
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
