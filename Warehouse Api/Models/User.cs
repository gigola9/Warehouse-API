using System;
using System.Collections.Generic;

#nullable disable

namespace Warehouse_Api.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Warehouse { get; set; }
    }
}
