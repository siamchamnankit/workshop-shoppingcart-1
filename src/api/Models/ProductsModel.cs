using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
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

    }

}
