﻿using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Class06.Domain
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
    }
}
