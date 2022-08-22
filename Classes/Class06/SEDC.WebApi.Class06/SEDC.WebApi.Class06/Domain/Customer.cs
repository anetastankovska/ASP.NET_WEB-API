using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Class06.Domain
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? AccountNumber { get; set; }
        public string? City { get; set; }
        public string? RegionName { get; set; }
        public string? CustomerSize { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
