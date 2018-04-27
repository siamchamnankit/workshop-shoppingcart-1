using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    
    [Table("orders")]
    public class OrdersModel
    {
        public int id { get; set; }
        public int cartId { get; set; }
        public int userId { get; set; }
        public decimal subtotal { get; set; }
        public decimal total { get; set; }
        public string shippingMethod { get; set; }
        public decimal shippingFee { get; set; }
        public string fullname {get; set;}
        public string address1{get;set;}
        public string address2{get;set;}
        public string city{get;set;}
        public string province{get;set;}
        public string postcode{get;set;}
        public DateTime createDatetime { get; set; }
    }

    [Table("order_products")]
    public class OrderProductsModel
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public decimal price { get; set; }
        public string availability { get; set; }
        public string brand { get; set; }
        public int stockAvailability { get; set; }
        
    }

    public class CreateOrderOutputModel
    {
        public int id { get; set; }

    }

    public class OrderDetailOutput
    {
        public OrdersModel order { get; set; }
        public ProductsListOutput products { get; set; }
    }

    public class ProductsListOutput {
        public int total { get; set; }
        public List<OrderProductsModel> data { get; set; }
    }
}