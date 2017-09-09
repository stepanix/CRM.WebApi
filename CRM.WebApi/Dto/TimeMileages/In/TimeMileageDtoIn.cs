﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.WebApi.Dto.TimeMileages.In
{
    public class TimeMileageDtoIn
    {
        public int Id { get; set; }
        public string UserId { get; set; }       
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double Duration { get; set; }
        public double Mileage { get; set; }
    }
}