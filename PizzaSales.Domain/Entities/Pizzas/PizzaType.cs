using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Domain.Models.Pizza
{
    public class PizzaType
    {
        public int PizzaTypeID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
