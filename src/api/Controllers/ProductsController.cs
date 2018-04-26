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
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ProductsListModel Get(string age = "", string gender = "")
        {
            return _productService.list(age, gender.ToUpper());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ProductsModel Get(int id)
        {
            return _productService.getProductDetail(id);
        }
    }
}
