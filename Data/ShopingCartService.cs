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

        public static async Task<string> SetCart(ShoppingCart cart, string token = "")
        {
            if (cart.Id == 0) return await PostCart(cart, token);
            var cartResult = await HttpService<string>.SendListAsync<string>("ShoppingCarts/"+ cart.Id, HttpMethod.Put, cart, token);
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

        public static async Task<string> Checkout(string token)
        {
            var checkoutResult = await HttpService<string>.SendListAsync<ShoppingCart>("ShoppingCarts/checkout", HttpMethod.Get, null, token);
            if(checkoutResult.HasErrors) return checkoutResult.Error;
            return "";
        }

        public static async Task<string> DeleteProduct(int prodctId, string token)
        {
            var checkoutResult = await HttpService<string>.SendListAsync<ShoppingCart>("ShoppingCarts/" + prodctId, HttpMethod.Delete, null, token);
            if (checkoutResult.HasErrors) return checkoutResult.Error;
            return "";
        }
    }
}
