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
        public double Price
        {
            get
            {
                return Product.Prices != null ? Product.Prices.FirstOrDefault().price_nal : 0;
            }
        }
        public double Summa
        {
            get
            {
                return Price * Count;
            }
        }
    }
}
