using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Theater_mdk.Data;
using Theater_mdk.Models;

namespace Theater_mdk.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public DetailsModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public Ticket? Ticket { get; set; }

        public IActionResult OnGet(int id)
        {
            Ticket = _context.Ticket
                        .Where(c => c.Id == id)
                        .FirstOrDefault();

            if (Ticket == null)
                return NotFound();

            return Page();
        }
    }
}
