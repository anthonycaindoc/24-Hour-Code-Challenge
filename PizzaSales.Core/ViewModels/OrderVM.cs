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
}
