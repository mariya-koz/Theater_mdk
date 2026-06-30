using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Theater_mdk.Data;
using Theater_mdk.Models;

namespace Theater_mdk.Pages.Audiences
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _context;
        public CreateModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Audience Audience { get; set; }
        public void OnGet() { }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Audiences.Add(Audience);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }

    }
}
