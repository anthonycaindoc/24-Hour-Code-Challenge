using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Features.Orders.Queries.GetOrders
{
    public class GetOrdersVM
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<GetOrderDetailsVM> OrderDetails { get; set; }
    }

    public class GetOrderDetailsVM
    {
        public int OrderDetailID { get; set; } 
        public int Quantity { get; set; }
        public GetOrderPizzaVM Pizza { get; set; }
    }

    public class GetOrderPizzaVM
    {
        public string PizzaCode { get; set; }
        public string PizzaTypeCode { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
