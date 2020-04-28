using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using Api_Domain;
using Api_Application.Repositories;
using Newtonsoft.Json;

namespace Api_Application.Controllers
{
    public class ProductController : ApiController
    {
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        [Route("api/getProducts")]
        public IHttpActionResult GetProducts()
        {
            List<Product> products = new List<Product>();
            using (ProductRepository _repo = new ProductRepository())
            {
                products = _repo.GetAllProducts();
            }
            string JsonProducts = JsonConvert.SerializeObject(products);

            return Ok(JsonProducts);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        [Route("api/GetProductMostExpensive")]
        public IHttpActionResult GetProductMostExpensive()
        {
            string JsonProduct = string.Empty;
            using (ProductRepository _repo = new ProductRepository())
            {
                JsonProduct = JsonConvert.SerializeObject(_repo.GetMostExpensiveProduct());
            }
           
            return Ok(JsonProduct);
        }
    }
}