using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Theater_mdk.Data;
using Theater_mdk.Models;

namespace Theater_mdk.Pages.Audiences
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public IndexModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Audience> Audiences { get; set; }

        public void OnGet()
        {
            Audiences = _context.Audiences.ToList();
        }
    }
}
