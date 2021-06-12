using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Models;
using Warehouse_Api.Models;
using Warehouse.Core.Auth;

namespace Warehouse_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        [HttpPost("Login")]
        public IActionResult Login(LoginInfo model)
        {
            try
            {
                WAREHOUSEContext obj = new WAREHOUSEContext();
                User nw = obj.Users.FirstOrDefault(m => m.Name == model.Nickname);

                if (nw is null)
                {
                    throw new Exception("სახელი ან პაროლი არასწორია");
                }

                string password = nw.Password;

                if (password == model.Password)
                {
                    LoginResponse res = new LoginResponse
                    {
                        NickName = nw.Name,
                        Role = nw.Role,
                        Success = true,
                        Warehouse = nw.Warehouse
                    };
                    return Ok(res); // 200
                }
                else
                {
                    throw new Exception("სახელი ან პაროლი არასწორია");
                }
            }
            catch (Exception ms)
            {
                return BadRequest(ms.Message); // 404
                // return BadRequest(ms.Message); 400=
            }
        }

        [HttpPost("Adduser")]
        public IActionResult AddUser(AddUser model)
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            User nw = new User()
            {
                Name = model.Name,
                Warehouse = model.Warehouse,
                Password = model.Password,
                Role = model.Role
            };
            obj.Users.Add(nw);
            obj.SaveChanges();
            return Ok();
        }

        [HttpPost("EditUser")]
        public IActionResult EditUser(EditUser model)
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            List<User> nw = obj.Users.ToList();

            User nn = nw.FirstOrDefault(m => m.Id == model.Id);

            nn.Name = model.Name;
            nn.Password = model.Password;
            nn.Role = model.Role;
            nn.Warehouse = model.Warehouse;

            obj.SaveChanges();
            return Ok();
        }
    }
}