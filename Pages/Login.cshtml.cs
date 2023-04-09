using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopLib;

namespace OnlineShop.Pages
{
    public class LoginModel : PageModel
    {
        public string ReturnUrl { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public User CurrentUser { get; set; }

        private ILocalStorageService localStorage;

        public LoginModel(ILocalStorageService storageService)
        {
            localStorage = storageService;
        }

        public async Task<IActionResult> OnGetAsync(string token)
        {
            User? user = await ShopLib.Auth.GetUserByToken(token);
            if (user != null)
            {
                string returnUrl = Url.Content("~/");
                try
                {
                    // Clear the existing external cookie
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
                catch { }
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.login), new Claim(ClaimTypes.Role, "Customer"), 
                                                new Claim("Id", user.ID.ToString()), new Claim("Token", token) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };
                try
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);

                    //Response.Cookies.Append("token", authResponce.Token);
                    //await localStorage.SetItemAsync(GenerateHash.CreateSHA256("access_token"), GenerateHash.CreateSHA256(AuthenticationToken));
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
                
                return LocalRedirect(returnUrl);
            }
            else
            {
                return LocalRedirect("~/");
            }
        }

    }
}
