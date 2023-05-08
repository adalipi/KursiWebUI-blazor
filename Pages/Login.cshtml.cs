using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using KursiWebUI.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KursiWebUI.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        private IAuthService _authService { get; set; }

        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        public class InputModel
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public async Task<IActionResult> OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return LocalRedirect("~/");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tokenObject = await _authService.LoginAsync(Input.Username, Input.Password);
                    if (tokenObject != null)
                    {

                        var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, "DisplayName", "");
                        claimsIdentity.AddClaim(new Claim("Token", tokenObject.Token));
                        var principal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return LocalRedirect("~/");
                    }

                    TempData["ErrorMessage"] = "Gabim. Provoni perseri.";
                }
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Gabim Serveri...";
                return Page();
            }
        }
    }
}
