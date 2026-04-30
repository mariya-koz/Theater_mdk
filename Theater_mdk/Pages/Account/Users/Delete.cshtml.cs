using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Theater_mdk.Data;
using Theater_mdk.Models.AuthApp;

namespace Theater_mdk.Pages.Account.Users
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public DeleteModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.AuthUsers.FindAsync(id);

            if (User == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _context.AuthUsers.FindAsync(User.Id);

            if (user != null)
            {
                _context.AuthUsers.Remove(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
