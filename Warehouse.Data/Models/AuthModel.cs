using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Data.Models
{
    public class AuthModel
    {

    }

    public class LoginResponse
    {
        public string NickName { get; set; }
        public string Role { get; set; }
        public bool Success { get; set; }
        public string Warehouse { get; set; }
    }

    public class LoginInfo
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
    }

    public class AddUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Warehouse { get; set; }
    }

    public class EditUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Warehouse { get; set; }
        public int Id { get; set; }
    }
}
