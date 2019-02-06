using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.Services
{
    public class ProductsService : IProductService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public ProductsListModel list(string age = "", string gender = "")
        {
            ProductsListModel productsList = new ProductsListModel();
            productsList.ProductsModel = this.list_products(age, gender);
            productsList.total = productsList.ProductsModel.Count();
            return productsList;
        }

        private List<ProductsModel> list_products(string age = "", string gender = "")
        {
            var products = _context.Products;
            if (age != "" && gender != "") {
                return products.Where(m => age != "" && m.age == age).Where(m => gender != "" && m.gender == gender).ToList();
            }
            if (age != "") {
                return products.Where(m => m.age == age).ToList();
            }
            if (gender != "") {
                return products.Where(m => m.gender == gender).ToList();
            }
            return products.ToList();
        }

        public ProductsModel getProductDetail(int id){
            return _context.Products.Where(m => m.id == id).FirstOrDefault();
        }
    }
}