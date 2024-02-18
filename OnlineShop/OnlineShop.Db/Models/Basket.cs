namespace OnlineShop.Db.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<BasketItem> BasketItems { get; set; }

        public Basket()
        {
            BasketItems = new List<BasketItem>();
        }
    }
}
