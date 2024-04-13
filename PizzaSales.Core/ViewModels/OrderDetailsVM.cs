namespace PizzaSales.Core.ViewModels
{
    public class OrderDetailsVM
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public PizzaVM Pizza { get; set; }
    }
}
