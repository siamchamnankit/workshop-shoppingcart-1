using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsService _productService;

        public ProductsController(ProductsService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ProductsListModel Get()
        {
            return _productService.list();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ProductsModel Get(int id)
        {
            return _productService.getProductDetail(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
