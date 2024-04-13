using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Domain.Models.Orders
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public string PizzaCode { get; set; }
        public DateTime Quantity { get; set; }
    }
}
