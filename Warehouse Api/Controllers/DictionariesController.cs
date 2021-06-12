using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse_Api.Models;

namespace Warehouse_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionariesController : ControllerBase
    {
        [HttpGet("CategoryDictionary")]
        public IActionResult CategoryDictionary()
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            List<ProductDictionary> nw = obj.ProductDictionaries.ToList();
            return Ok(nw);
        }

        [HttpGet("ProductDictionary")]
        public IActionResult ProductDictionary()
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            List<Product> nw = obj.Products.Where(m => m.Status == "done").ToList();
            return Ok(nw);
        }

        [HttpGet("PendingProductDictionary")]
        public IActionResult PendingProductDictionary()
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            List<Product> nw = obj.Products.Where(m => m.Status == "pending").ToList();
            return Ok(nw);
        }

        [HttpGet("StorageDictionary")]
        public IActionResult StorageDictionary()
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            List<Storage> nw = obj.Storages.ToList();
            return Ok(nw);
        }

        [HttpGet("ActivitiyDictionary")]
        public IActionResult ActivitiyDictionary()
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            List<Activity> nw = obj.Activities.ToList();
            return Ok(nw);
        }

        [HttpGet("WarehouseDictionary")]
        public IActionResult WarehouseDictionary()
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            var nw = obj.Warehouses.ToList();
            return Ok(nw);
        }

        [HttpGet("UserDictionary")]
        public IActionResult UserDictionary()
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            List<User> nw = obj.Users.ToList();
            return Ok(nw);
        }
    }
}