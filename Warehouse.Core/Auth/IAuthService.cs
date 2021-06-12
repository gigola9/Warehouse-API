using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Data.Models;

namespace Warehouse.Core.Auth
{
    public interface IAuthService
    {
        LoginResponse Login(LoginInfo model);
    }
}
