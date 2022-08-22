using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Class06.Domain
{
    public partial class OrderDetail
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
