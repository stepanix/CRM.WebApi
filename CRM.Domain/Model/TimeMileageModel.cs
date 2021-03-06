﻿using System;


namespace CRM.Domain.Model
{
    public class TimeMileageModel
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Duration { get; set; }
        public double Mileage { get; set; }
        public string CreatorUserId { get; set; }
        public string LastModifierUserId { get; set; }
        public int TenantId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }        
        public DateTime DateCreated { get; set; }
    }
}
