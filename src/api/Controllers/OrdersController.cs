using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {

        private readonly OrdersService _ordersService;

        public OrdersController(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]OrdersModel order)
        {
            int userId = 1;
            return Json(_ordersService.create(order.id, userId));
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public OrderDetailOutput Get(int id)
        {
            return _ordersService.get(id);
        }

    }
}
