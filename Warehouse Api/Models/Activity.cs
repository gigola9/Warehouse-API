using System;
using System.Collections.Generic;

#nullable disable

namespace Warehouse_Api.Models
{
    public partial class Activity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? ProductId { get; set; }
        public int? ProductCode { get; set; }
        public string Username { get; set; }
        public DateTime? Date { get; set; }
        public int? Amount { get; set; }
        public string Giver { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }
    }
}
