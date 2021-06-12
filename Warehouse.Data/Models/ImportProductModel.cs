using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Data.Models
{
    public class ImportProductModel
    {
        public string User { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Giver { get; set; }
        public int? Amount { get; set; }
        public string Description { get; set; }
    }
}
