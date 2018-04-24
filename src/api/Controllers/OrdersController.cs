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
        public OrdersController()
        {
            
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]OrdersModel order)
        {
            String response = "{id:" + order.id + "}";
            return Json(JObject.Parse(response));
        }

    }
}
