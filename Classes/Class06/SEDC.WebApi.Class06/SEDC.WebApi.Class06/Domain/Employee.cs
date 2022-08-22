using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Class06.Domain
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public DateTime? HireDate { get; set; }
        public string? NationalIdNumber { get; set; }
    }
}
