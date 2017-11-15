﻿using System;

namespace CRM.Domain.Model
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }       
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public string ActivityLog { get; set; }
        public string ActivityTypeId { get; set; }
        public int TenantId { get; set; }
        public TenantModel Tenant { get; set; }
        public FormValueModel FormValue { get; set; }
        public PhotoModel Photo { get; set; }
        public NoteModel Note { get; set; }
        public ProductRetailAuditModel ProductRetailAudit { get; set; }
        public OrderModel Order { get; set; }        
        public DateTime AddedDate { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
