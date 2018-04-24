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
        private readonly CartsService _cartService;

        public CartsController(CartsService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IEnumerable<CartsModel> Get()
        {
            return _cartService.list();
        }
        
        [HttpGet("{id}")]
        public CartsModel GetCart(int id)
        {
            return _cartService.getCart(1, 1);
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]AddCartInputModel product)
        {
            return Json(_cartService.add(product.id, product.quantity));
        }

    }
}
