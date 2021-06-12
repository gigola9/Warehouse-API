using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Models;
using Warehouse_Api.Models;

namespace Warehouse_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        [HttpPost("AddWarehouse")]
        public IActionResult AddWarehouse(WarehouseModel model)
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            Models.Warehouse newWarehouse = new Models.Warehouse()
            {
                Address = model.Address,
                Name = model.Name,
                Number = model.Number
            };

            obj.Warehouses.Add(newWarehouse);
            obj.SaveChanges();
            return Ok();
        }
    }
}