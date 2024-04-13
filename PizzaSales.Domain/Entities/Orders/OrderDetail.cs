namespace PizzaSales.Domain.Models.Orders
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public string PizzaCode { get; set; }
        public int Quantity { get; set; }
    }
}
