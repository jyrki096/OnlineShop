using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ImageLink { get; set; }
        public List<string> ImageLinks { get; set; }

        [Precision(18, 5)]
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public Сharacteristics? Characteristics { get; set; }
        public List<BasketItem> BasketItems { get; set; }

        public Product()
        {
            BasketItems = new List<BasketItem>();
        }
    }
}
