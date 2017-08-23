using CRM.Domain.Entity.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Schedule : BaseEntity<int>
    {
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime VisitDate { get; set; }
        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime VisitTime { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Recurring { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(1000)]
        public string VisitNote { get; set; }
    }
}
