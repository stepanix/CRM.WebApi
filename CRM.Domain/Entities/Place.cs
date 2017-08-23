using CRM.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Place : BaseEntity<int>
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(1000)]
        public string StreetAddress { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string City { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string State { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Zip { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string ZipExtension { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Country { get; set; }

        [ForeignKey("Status")]
        public int? StatusId { get; set; }
        public Status Status { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(1000)]
        public string WebSite { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string ContactName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string ContactTitle { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string Phone { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string CellPhone { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(2000)]
        public string Comment { get; set; }

    }
}
