using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Class06.Domain
{
    public partial class EmployeesThatMadeOrder
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? HireDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Name { get; set; } = null!;
    }
}
