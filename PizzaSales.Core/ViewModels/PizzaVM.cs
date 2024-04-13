using PizzaSales.Domain.Models.Pizza;

namespace PizzaSales.Core.ViewModels
{
    public class PizzaVM
    {
        public Pizza Pizza { get; set; }
        public PizzaType PizzaType { get; set; }
    }
}
