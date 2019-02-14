using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Table("coupons")]
    public class CouponModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public decimal discount { get; set; }
        public decimal min_spending { get; set; }
        public int limit { get; set; }
        public int count { get; set; }
        public DateTime createDatetime { get; set; }
        public DateTime updateDatetime { get; set; }
    }

}