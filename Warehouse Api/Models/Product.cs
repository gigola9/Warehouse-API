using System;
using System.Collections.Generic;

#nullable disable

namespace Warehouse_Api.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Giver { get; set; }
        public string Category { get; set; }
        public int? Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
