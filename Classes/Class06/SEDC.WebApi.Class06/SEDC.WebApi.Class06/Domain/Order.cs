using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Class06.Domain
{
    public partial class Order
    {
        public long Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public short? Status { get; set; }
        public int? BusinessEntityId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Comment { get; set; }
    }
}
