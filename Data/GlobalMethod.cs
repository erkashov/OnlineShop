namespace OnlineShop.Data
{
    public static class GlobalMethod
    {
        public static async Task<int> GetProductStock(int productId)
        {
            int stock = 0;
            stock = await BaseHttpService<int>.SendAsync<int>("Sklad_tov_OSTATKI/" + productId, HttpMethod.Get);
            return stock;
        }
    }
}
