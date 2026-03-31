using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater_mdk.Data;
using Theater_mdk.Models;

namespace Theater_mdk.Pages.Audiences
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public IndexModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Audience> Audience { get; set; }

        public void OnGet()
        {
            Audience = _context.Audiences.ToList();
        }
    }
}
