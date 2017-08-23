﻿using System;


namespace CRM.Domain.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
