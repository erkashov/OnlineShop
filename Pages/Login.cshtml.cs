using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Models;
using ShopLib;

namespace OnlineShop.Pages
{
    public class LoginModel : PageModel
    {
        public string ReturnUrl { get; set; }
        private ILocalStorageService localStorage;

        public LoginModel(ILocalStorageService storageService)
        {
            localStorage = storageService;
        }

        public async Task<IActionResult>
            OnGetAsync(string paramUsername, string paramPassword)
        {
            User CurrentUser = new User();
            string returnUrl = Url.Content("~/");
            try
            {
                // Clear the existing external cookie
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }
            // *** !!! This is where you would validate the user !!! ***
            // In this example we just log the user in
            // (Always log the user in for this demo)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, paramUsername),
                new Claim(ClaimTypes.Role, "Customer"),
            };
            CurrentUser = new User() { name = "Customer", login = paramUsername/*, Phone = "+79172416373" */};
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value
            };
            try
            {
                await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimsIdentity), authProperties);
                
                await localStorage.SetItemAsync("CurrentUser", CurrentUser);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return LocalRedirect(returnUrl);
        }
    }
}
