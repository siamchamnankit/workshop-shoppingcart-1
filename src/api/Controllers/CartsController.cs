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
    public class CartsController : Controller
    {
        private readonly ICartsService _cartService;
        private readonly IProductService _productService;

        public CartsController(ICartsService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<CartsModel> Get()
        {
            return _cartService.list();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]AddCartInputModel product)
        {
            ProductsModel productModel = _productService.getProductDetail(product.id);
            return Json(_cartService.add(productModel, product.quantity));
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
