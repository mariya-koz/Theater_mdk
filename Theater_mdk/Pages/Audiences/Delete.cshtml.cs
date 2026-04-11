using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Theater_mdk.Data;
using Theater_mdk.Models;

namespace Theater_mdk.Pages.Audiences
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public DeleteModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Audience Audience { get; set; }

        public IActionResult OnGet(int id)
        {
            Audience = _context.Audiences.Find(id);

            if (Audience == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var student = _context.Audiences.Find(Audience.Id);

            if (student != null)
            {
                _context.Audiences.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
