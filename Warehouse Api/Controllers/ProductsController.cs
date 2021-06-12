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
    public class ProductsController : ControllerBase
    {
        [HttpPost("Addprocut")]
        public IActionResult Addproduct(AddProductModel model)
        {
            try
            {
                WAREHOUSEContext obj = new WAREHOUSEContext();
                Product nw = new Product()
                {
                    Category = model.Category,
                    Code = model.Code,
                    Description = model.Description,
                    Giver = model.Giver,
                    Name = model.Name,
                    Status = "pending"
                };
                obj.Products.Add(nw);
                obj.SaveChanges();
                SuccessResModel res = new SuccessResModel()
                {
                    Success = true,
                    Error = ""
                };
                return Ok(res); // 200
            }
            catch (Exception ms)
            {
                SuccessResModel res = new SuccessResModel()
                {
                    Success = false,
                    Error = ms.Message
                };
                return BadRequest(res);
            }
        }

        [HttpPost("ImportProduct")]
        public IActionResult ImportProduct(ImportProductModel model)
        {
            try
            {
                WAREHOUSEContext obj = new WAREHOUSEContext();
                Product product = obj.Products.FirstOrDefault(m => m.Name == model.Name);
                Activity activity = new Activity()
                {
                    Amount = model.Amount,
                    Comment = model.Description,
                    Date = Convert.ToDateTime(model.Date),
                    Giver = model.Giver,
                    ProductCode = product.Code,
                    ProductId = product.Id,
                    ProductName = model.Name,
                    Username = model.User,
                    Type = "import"
                };
                obj.Activities.Add(activity);

                List<Storage> stg = obj.Storages.ToList();
                for (int i = 0; i < stg.Count; i++)
                {
                    if (stg[i].Name == model.Name)
                    {
                        stg[i].Amount = stg[i].Amount + model.Amount;
                    }
                }

                if (!stg.Any(m => m.Name == model.Name))
                {
                    Storage addInstg = new Storage()
                    {
                        Amount = model.Amount,
                        Name = model.Name,
                        ProductCode = product.Code,
                        ProductId = product.Id
                    };
                    obj.Storages.Add(addInstg);
                }

                obj.SaveChanges();
                SuccessResModel res = new SuccessResModel()
                {
                    Success = true,
                    Error = ""
                };
                return Ok(res);
            }
            catch (Exception ms)
            {
                SuccessResModel res = new SuccessResModel()
                {
                    Success = false,
                    Error = ms.Message
                };
                return BadRequest(res);
            }
        }

        [HttpPost("ExportProduct")]
        public IActionResult ExportProduct(ImportProductModel model)
        {
            try
            {
                WAREHOUSEContext obj = new WAREHOUSEContext();
                Product product = obj.Products.FirstOrDefault(m => m.Name == model.Name);

                List<Storage> stg = obj.Storages.ToList();
                for (int i = 0; i < stg.Count; i++)
                {
                    if (stg[i].Name == model.Name)
                    {
                        if (stg[i].Amount >= model.Amount)
                        {
                            stg[i].Amount = stg[i].Amount - model.Amount;
                        }
                        else
                        {
                            throw new Exception("არ არის საკმარისი მარაგი");
                        }
                    }
                }

                if (!stg.Any(m => m.Name == model.Name))
                {
                    throw new Exception("არ არის საკმარისი მარაგი");
                }

                Activity activity = new Activity()
                {
                    Amount = model.Amount,
                    Comment = model.Description,
                    Date = Convert.ToDateTime(model.Date),
                    Giver = model.Giver,
                    ProductCode = product.Code,
                    ProductId = product.Id,
                    ProductName = model.Name,
                    Username = model.User,
                    Type = "export"
                };
                obj.Activities.Add(activity);

                obj.SaveChanges();
                SuccessResModel res = new SuccessResModel()
                {
                    Success = true,
                    Error = ""
                };
                return Ok(res);
            }
            catch (Exception ms)
            {
                SuccessResModel res = new SuccessResModel()
                {
                    Success = false,
                    Error = ms.Message
                };
                return BadRequest(res);
            }
        }

        [HttpPost("Manageproducts")]
        public IActionResult Manageproducts(ManageProductsModule model)
        {
            WAREHOUSEContext obj = new WAREHOUSEContext();
            List<Product> nw = obj.Products.ToList();
            Product product = obj.Products.FirstOrDefault(m => m.Name == model.Name);

            if (model.Status == "accept")
            {
                product.Status = "done";
            }
            else if (model.Status == "reject")
            {
                obj.Products.Remove(product);
            }

            obj.SaveChanges();
            return Ok();
        }
    }
}