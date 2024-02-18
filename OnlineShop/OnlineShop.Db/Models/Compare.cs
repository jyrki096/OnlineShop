namespace OnlineShop.Db.Models
{
    public class Compare
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Product Product { get; set; }
    }
}
