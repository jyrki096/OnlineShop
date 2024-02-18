using System;

namespace OnlineShopWebApp.Models
{
    public class BasketItemViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Amount { get; set; }

        public decimal Total()
        {
            return Product.Cost * Amount;
        }
    }
}
