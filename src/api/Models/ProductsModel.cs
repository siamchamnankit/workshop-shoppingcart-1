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

    public class ProductInCartModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public decimal price { get; set; }
        public string availability { get; set; }
        public string brand { get; set; }
        public int stockAvailability { get; set; }
        public int quantity { get; set; }
            
        public override bool Equals(object obj)
        {
            ProductInCartModel productInCart = obj as ProductInCartModel;

            if (productInCart == null)
                return false;

            if (productInCart.id != id)
                return false;

            if (productInCart.name != name)
                return false;

            if (productInCart.gender != gender)
                return false;

            if (productInCart.age != age)
                return false;

            if (productInCart.price != price)
                return false;

            if (productInCart.brand != brand)
                return false;

            if (productInCart.stockAvailability != stockAvailability)
                return false;

            if (productInCart.quantity != quantity)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return id;
        }
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