using ShopLib;

namespace OnlineShop.Data
{
    public class ProductCart
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public Product Product { get; set; }
        public string ImagePath { get; set; }
    }
}
