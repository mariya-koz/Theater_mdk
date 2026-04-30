using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Theater_mdk.Data;
using Theater_mdk.Models.AuthApp;

namespace Theater_mdk.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel(ApplicationDBContext context) : PageModel
    {
        private readonly ApplicationDBContext _context = context;

        [BindProperty]
        public AuthUser User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.AuthUsers.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
