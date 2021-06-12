using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Data.Models
{
    public class AddProductModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Giver { get; set; }
        public int? Code { get; set; }
        public string Description { get; set; }
    }
}
