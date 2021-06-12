using System;
using System.Collections.Generic;

#nullable disable

namespace Warehouse_Api.Models
{
    public partial class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
    }
}
