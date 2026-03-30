using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Theater_mdk.Data;
using Theater_mdk.Models;

namespace Theater_mdk.Pages.Audiences
{
    public class DetailsModel : PageModel
    {
        private readonly Theater_mdk.Data.ApplicationDBContext _context;

        public DetailsModel(Theater_mdk.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public Audience Audience { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audience = await _context.Audiences.FirstOrDefaultAsync(m => m.Id == id);

            if (audience is not null)
            {
                Audience = audience;

                return Page();
            }

            return NotFound();
        }
    }
}
