using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.Services
{
    public class ProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        internal IEnumerable<ProductsModel> list()
        {
             return _context.Products.ToList();
        }

        public ProductsModel getProductDetail(int id){
            return _context.Products.Where(m => m.id == id).FirstOrDefault();
        }
    }
}