using ShopLib;

namespace OnlineShop.Data
{
    public class ShopingCartService
    {
        public static async Task<ShoppingCart> GetCart()
        {
            ShoppingCart cart = new ShoppingCart();
            var cartResult = await HttpService<ShoppingCart>.SendListAsync<ShoppingCart>("ShoppingCarts", HttpMethod.Get);
            if (!cartResult.HasErrors)
            {
                cart = cartResult.Responce.FirstOrDefault();
            }
            return cart;
        }

        public static async Task<string> SetCart(ShoppingCart cart)
        {
            var cartResult = await HttpService<string>.SendListAsync<ShoppingCart>("ShoppingCarts/"+ cart.Id, HttpMethod.Put, cart);
            if (cartResult.HasErrors)
            {
                return cartResult.Error;
            }
            return "";
        }

        public static async Task<string> PostCart(ShoppingCart cart, string token = "")
        {
            var cartResult = await HttpService<string>.SendListAsync<ShoppingCart>("ShoppingCarts", HttpMethod.Post, cart, token);
            if (cartResult.HasErrors)
            {
                return cartResult.Error;
            }
            return "";
        }
    }
}
