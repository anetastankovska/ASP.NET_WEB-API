using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Class06.Domain
{
    public partial class BusinessEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? ZipCode { get; set; }
        public string? Size { get; set; }
    }
}
