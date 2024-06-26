﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaSales.Domain.Models.Pizza
{
    public class Pizza
    {
        public int PizzaID { get; set; }
        public string Code { get; set; }
        public string PizzaTypeCode { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
