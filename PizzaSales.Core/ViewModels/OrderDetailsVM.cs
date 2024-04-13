namespace PizzaSales.Core.ViewModels
{
    public class OrderDetailsVM
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal
        {
            get
            {
                return Pizza.Pizza.Price * Quantity;
            }
        }
        public PizzaVM Pizza { get; set; }
    }
}
