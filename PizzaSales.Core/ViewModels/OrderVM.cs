using PizzaSales.Domain.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.ViewModels
{
    public class OrderVM
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderDetailsVM> OrderDetails { get; set; }
    }

    public class OrderDetailsVM
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public PizzaVM Pizza { get; set; }
    }

    public class PizzaVM
    {
        public Pizza Pizza { get; set; }
        public PizzaType PizzaType { get; set; }
    }
}
