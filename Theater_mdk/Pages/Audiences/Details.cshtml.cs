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
        private readonly ApplicationDBContext _context;

        public DetailsModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public Audience Student { get; set; }

        public IActionResult OnGet(int id)
        {
            Student = _context.Audiences.FirstOrDefault(s => s.Id == id);

            if (Student == null)
                return NotFound();

            return Page();
        }
    }
}
