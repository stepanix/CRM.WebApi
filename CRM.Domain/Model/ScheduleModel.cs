﻿using System;


namespace CRM.Domain.Model
{
    public class ScheduleModel
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime? VisitTime { get; set; }
        public string VisitNote { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatorUserId { get; set; }
        public string LastModifierUserId { get; set; }
        public int TenantId { get; set; }
        public bool IsRepeat { get; set; }
        public int? RepeatCycle { get; set; }
        public bool IsVisited { get; set; }
        public bool IsScheduled { get; set; }
        public bool IsMissed { get; set; }
        public bool IsUnScheduled { get; set; }
        public string VisitStatus { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string RepoId { get; set; }
    }
}
