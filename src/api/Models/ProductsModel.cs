using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class ProductsListModel
    {
        public int total { get; set; }
        public List<ProductsModel> ProductsModel { get; set; }

    }

    [Table("products")]
    public class ProductsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public decimal price { get; set; }
        public string availability { get; set; }
        public string brand { get; set; }
        public int stockAvailability { get; set; }

        public List<CartProductsModel> CartProducts { get; set; }

    }
}