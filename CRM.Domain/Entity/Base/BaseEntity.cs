using CRM.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entity.Base
{
    public abstract class BaseEntity<TPrimaryKey> : IEntity<TPrimaryKey>, ISoftDelete
    {
        public virtual TPrimaryKey Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        private bool IsActive { get; set; }
    }
}
