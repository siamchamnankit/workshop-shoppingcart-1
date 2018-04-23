using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Table("cart")]
    public class CartsModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public decimal subtotal { get; set; }
        public decimal total { get; set; }
        public string shippingMethod { get; set; }
        public decimal shippingFee { get; set; }
        public int shippingId { get; set; }
        public DateTime createDatetime { get; set; }
        public DateTime updateDatetime { get; set; }

        public List<CartProducts> cartProducts { get; set; }
    }

    [Table("cart_product")]
    public class CartProducts
    {
        public int id { get; set; }
        public int cartId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
    }
}