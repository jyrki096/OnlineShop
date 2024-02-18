namespace OnlineShop.Db.Models
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public string UserName {  get; set; }
        public Product Product { get; set; }
    }
}
