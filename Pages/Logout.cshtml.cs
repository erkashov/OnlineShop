using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineShop.Pages
{
    public class LogoutModel : PageModel
    {
        private ILocalStorageService localStorage;

        public LogoutModel(ILocalStorageService storageService)
        {
            localStorage = storageService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //await localStorage.RemoveItemAsync("CurrentUser");
            return LocalRedirect(Url.Content("~/"));
        }
    }
}
