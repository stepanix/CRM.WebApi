﻿

using System;

namespace CRM.Domain.Model
{
    public class StatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatorUserId { get; set; }
        public string LastModifierUserId { get; set; }
        public int TenantId { get; set; }
    }
}
