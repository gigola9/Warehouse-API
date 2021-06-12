using System;
using System.Collections.Generic;

#nullable disable

namespace Warehouse_Api.Models
{
    public partial class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProductId { get; set; }
        public int? ProductCode { get; set; }
        public int? Amount { get; set; }
    }
}
