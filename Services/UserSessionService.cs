using ShopLib;
namespace OnlineShop.Services
{
    public interface IUserSessionService
    {
        /*void SetUserData(User userData);
        User GetUserData();*/
        void SetToken(string token);
        string GetToken();
    }
    public class UserSessionService : IUserSessionService
    {
        private string Token;
        public void SetToken(string token)
        {
            Token = token;
        }
        public string GetToken()
        {
            return Token;
        }
    }
}
