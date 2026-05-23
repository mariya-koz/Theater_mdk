using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Theater_mdk.Data;
using Theater_mdk.Models.AuthApp;

namespace Theater_mdk.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _context;
        public CreateModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthUser User { get; set; }
        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public void OnGet()
        {
            User = new AuthUser();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (ImageFile != null)
            {
                if (ImageFile.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "File too large");
                    return Page();
                }

                using (var ms = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(ms);
                    User.Image = ms.ToArray();
                }
            }
            if (User.Id > 0) 
            {
                _context.Attach(User).State = EntityState.Modified;
            }
            else
            {
                await _context.AuthUsers.AddAsync(User);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
