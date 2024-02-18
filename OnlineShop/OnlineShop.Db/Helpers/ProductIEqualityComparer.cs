using OnlineShop.Db.Models;
using System.Diagnostics.CodeAnalysis;


namespace OnlineShop.Db.Helpers
{
    internal class ProductIEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return HashCode.Combine(obj.Id);
        }
    }
}
