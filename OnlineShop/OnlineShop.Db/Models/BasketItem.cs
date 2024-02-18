namespace OnlineShop.Db.Models
{
    public class BasketItem
    {
        public Guid Id { get; set; }    
        public Product Product { get; set; }
        public Basket Basket { get; set; }
        public int Amount { get; set; }
    }
}
