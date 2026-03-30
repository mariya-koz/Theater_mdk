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
    public class IndexModel : PageModel
    {
        private readonly Theater_mdk.Data.ApplicationDBContext _context;

        public IndexModel(Theater_mdk.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Audience> Audience { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Audience = await _context.Audiences.ToListAsync();
        }
    }
}
