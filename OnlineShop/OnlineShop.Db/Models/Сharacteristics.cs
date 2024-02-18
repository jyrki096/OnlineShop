namespace OnlineShop.Db.Models
{
    public class Сharacteristics
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public string Power { get; set; }
        public string Polyphony { get; set; }
        public string Timbers { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
