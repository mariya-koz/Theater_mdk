using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Theater_mdk.Data;
using Theater_mdk.Models.AuthApp;

namespace Theater_mdk.Pages.Account
{
    public class RegistrModel : PageModel
    {
            private readonly ApplicationDBContext _context;

            public RegistrModel(ApplicationDBContext context)
            {
                _context = context;
            }

            [BindProperty]
            public Models.AuthApp.Registr Input { get; set; }

            public void OnGet() { }

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                    return Page();

                bool isFirstUser = !_context.AuthUsers.Any();

                var user = _context.AuthUsers.FirstOrDefault(u => u.Email == Input.Email);

                if (user == null)
                {
                    user = new AuthUser { Name = Input.Email, Email = Input.Email, Password = Input.Password, Role = isFirstUser ? "Admin" : "User" };
                    _context.AuthUsers.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user.Email, user.Role);
                    return RedirectToPage("/Index");
                }

                ModelState.AddModelError(string.Empty, "Пользователь уже есть!");
                return Page();
            }

            private async Task Authenticate(string userName, string role)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };

                var identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }

            //private readonly ApplicationDBContext _context;

            //public RegistrModel(ApplicationDBContext context)
            //{
            //    _context = context;
            //}

            //[BindProperty]
            //public Models.AuthApp.Registr Input { get; set; }

            //public void OnGet() { }

            //public async Task<IActionResult> OnPostAsync()
            //{
            //    if (!ModelState.IsValid)
            //        return Page();

            //    bool isFirstUser = !_context.AuthUser.Any();

            //    var user = _context.AuthUser.FirstOrDefault(u => u.Email == Input.Email);

            //    if (user == null)
            //    {
            //        user = new AuthUser { Email = Input.Email, Password = Input.Password, Role = isFirstUser ? "Admin" : "User" };
            //        _context.AuthUser.Add(user);
            //        await _context.SaveChangesAsync();

            //        await Authenticate(user.Email, user.Role);
            //        return RedirectToPage("/Index");
            //    }

            //    ModelState.AddModelError(string.Empty, "Пользователь уже есть!");
            //    return Page();
            //}

            //private async Task Authenticate(string userName, string role)
            //{
            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
            //        new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            //    };

            //    var identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            //    var principal = new ClaimsPrincipal(identity);

            //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            //}
        }
    }

